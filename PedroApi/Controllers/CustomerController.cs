using PedroApi.ViewModels;
using PedroApi.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<CustomerGet> Get(long customerId)
        {
            try
            {
                var customerData = _customerService.FindCustomer(customerId);
                CustomerGet customerResponse = new CustomerGet();
                if (customerData != null)
                {
                    customerResponse = _mapper.Map<CustomerGet>(customerData);
                }
                return new OkObjectResult(customerResponse);
            }
            catch (Exception ex) { 
                throw new System.Web.Http.HttpResponseException(System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}