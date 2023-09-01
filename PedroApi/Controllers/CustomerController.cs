using Microsoft.AspNetCore.Mvc;
using PedroApi.ViewModels;
using PedroApi.Services;
using AutoMapper;

namespace PedroApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(
            ILogger<CustomerController> logger,
            ICustomerService customerService,
            IMapper mapper
            )
        {
            _mapper = mapper;
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
                customerResponse = _mapper.Map<CustomerGet>(customerData);
            }
            return customerResponse;
        }
    }
}