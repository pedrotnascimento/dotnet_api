using Microsoft.AspNetCore.Mvc;
using PedroApi.DTO;
using PedroApi.Services;

namespace PedroApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(
            ILogger<CustomerController> logger,
            ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet("{customerId}")]
        public CustomerGet Get(long customerId)
        {
            var customerData = _customerService.FindCustomer(customerId);
            CustomerGet customerResponse = new CustomerGet();
            if (customerData != null)
            {
                customerResponse.CustomerId = customerData.CustomerId;
                customerResponse.Name = customerData.Name;
                customerResponse.Balance = customerData.Balance;
            }
            return customerResponse;
        }
    }
}