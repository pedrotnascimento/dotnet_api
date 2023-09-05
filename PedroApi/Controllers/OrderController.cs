using Microsoft.AspNetCore.Mvc;
using PedroApi.ViewModels;
using PedroApi.Models;
using PedroApi.Services;
using PedroApi.DTO;

namespace PedroApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {

        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;

        public OrderController(
            ILogger<OrderController> logger,
            IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        [HttpGet("{customerId}")]
        public ActionResult<List<OrderCollectionGet>> Get(long customerId,
            [FromQuery(Name = "start_date")] DateTime startDate,
            [FromQuery(Name = "end_date")] DateTime endDate)
        {
            try
            {

                var orderData = _orderService.FindByCustomerAndDateInterval(customerId, startDate, endDate);
                List<OrderCollectionGet> orderResponse = new List<OrderCollectionGet>();
                if (orderData.Any())
                {
                    orderResponse = PresentOrderList(orderData);
                }
                return new OkObjectResult(orderResponse);
            }
            catch (Exception ex)
            {
                throw new System.Web.Http.HttpResponseException(System.Net.HttpStatusCode.InternalServerError);
            }

        }

        [HttpPost()]
        public ActionResult<OrderCollectionGet> Post([FromBody] OrderCreate order)
        {
            try
            {
                var orderData = _orderService.CreateOrder(order);
                OrderCollectionGet orderResponse = new OrderCollectionGet();
                if (orderData != null)
                {
                    orderResponse = PresentOrder(orderData);
                }
                return new OkObjectResult(orderResponse);
            }
            catch (Exception ex)
            {
                throw new System.Web.Http.HttpResponseException(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        private List<OrderCollectionGet> PresentOrderList(List<OrderDto> orderData)
        {
            return orderData.Select(x =>
            {
                return PresentOrder(x);
            }).ToList();
        }

        private OrderCollectionGet PresentOrder(OrderDto order)
        {
            var orderResponse = new OrderCollectionGet();
            orderResponse.CustomerId = order.CustomerId;
            orderResponse.OrderDate = order.OrderDate;
            orderResponse.OrderId = order.OrderId;
            orderResponse.Total = order.GetTotalCost();
            List<OrderProductGet> lineItems = PresentProductsWithinOrder(order);
            orderResponse.LineItems = lineItems;
            return orderResponse;
        }

        private List<OrderProductGet> PresentProductsWithinOrder(OrderDto order)
        {
            return order.OrderProducts.Select(orderProduct =>
            {
                var orderProductResponse = new OrderProductGet();
                orderProductResponse.TotalCost = orderProduct.GetProductTotalCost();
                orderProductResponse.ProductName = orderProduct.GetProductName();
                orderProductResponse.ProductId = orderProduct.ProductId;
                orderProductResponse.QuantityPurchased = orderProduct.Quantity;
                return orderProductResponse;
            }).ToList();
        }
    }
}