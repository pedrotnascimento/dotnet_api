using Microsoft.EntityFrameworkCore;
using PedroApi.ViewModels;
using PedroApi.Models;
using PedroApi.Repositories;
using PedroApi.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace PedroApi.Services
{
    public class OrderService : IOrderService
    {
        private const string CUSTOMER_NOT_FOUND_ERROR = "Customer doesnt exists";
        private const string NOT_ENOUGH_PRODUCT_ERROR = "Not enough Products for purchase in the storage";
        private const string CUSTOMER_LOW_BALANCE_ERROR = "Customer has low balance";
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly OrderApiDatabasedbContext _dbContext;

        public OrderService(
            IOrderRepository orderRepository,
            ICustomerRepository customerRepository,
            IProductRepository productRepository,
            IMapper mapper 
            )
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public List<OrderDto> FindByCustomerAndDateInterval(long customerId, DateTime startDate, DateTime endDate)
        {
            var orders = _orderRepository.FindByCustomerAndDateInterval(customerId, startDate, endDate);
            return _mapper.Map<List<OrderDto>>(orders);
        }

        public OrderDto CreateOrder(OrderCreate orderCreate)
        {
            float totalCost = 0;
            Orders savingCandidate = new Orders();
            var productsListForSaving = new List<Products>();
            using (var context = new OrderApiDatabasedbContext())
            {   //Breaking Segregation between service and repository for performance reasons
                //Using context in Order Service So it doesnt need to create a lot of connections to the database
                //We can read and save instances in only one connection
                var customer = context.Customers.FirstOrDefault(c => c.CustomerId == orderCreate.CustomerId);
                
                if (customer == null)
                {
                    throw new Exception(CUSTOMER_NOT_FOUND_ERROR);
                }

                orderCreate.Products.ForEach(purchasingProduct =>
                {
                    var requestedProduct = context.Products.First(x => purchasingProduct.ProductId == x.ProductId);
                    if (requestedProduct.Quantity < purchasingProduct.Quantity)
                    {
                        throw new Exception(NOT_ENOUGH_PRODUCT_ERROR);
                    }
                    totalCost += requestedProduct.Price * purchasingProduct.Quantity;
                    if (totalCost > customer.Balance)
                    {
                        throw new Exception(CUSTOMER_LOW_BALANCE_ERROR);
                    }
                    requestedProduct.Quantity -= purchasingProduct.Quantity;
                    productsListForSaving.Add(requestedProduct);
                });
                
                customer.Balance -= totalCost;
                context.SaveChanges();
            }

            savingCandidate.OrderDate = DateTime.Now;
            savingCandidate.CustomerId = orderCreate.CustomerId;
            savingCandidate.OrderProducts = orderCreate.Products.Select(x =>
            {
                var productLooked = productsListForSaving.First(y => y.ProductId == x.ProductId);
                var orderProduct = new OrderProducts();
                orderProduct.ProductId = productLooked.ProductId;
                orderProduct.Quantity = productLooked.Quantity;
                return orderProduct;
            }).ToList();
            
            _orderRepository.SaveOrder(savingCandidate);

            var results = _mapper.Map<OrderDto>(savingCandidate);
            results.OrderProducts = results.OrderProducts.Select(x =>
            {
                var productLooked = productsListForSaving.First(y => y.ProductId == x.ProductId);
                x.Product = productLooked;
                return x;
            }).ToList();

            return results;
        }
    }
}
