using PedroApi.Models;
using PedroApi.Repositories;

namespace PedroApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(
            ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public Customers? FindCustomer(long customerId)
        {
            return _customerRepository.FindOne(customerId);
        }
    }
}
