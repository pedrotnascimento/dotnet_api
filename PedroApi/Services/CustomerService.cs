using AutoMapper;
using PedroApi.DTO;
using PedroApi.Models;
using PedroApi.Repositories;

namespace PedroApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(
            ICustomerRepository customerRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        public CustomerDto? FindCustomer(long customerId)
        {
            var customer = _customerRepository.FindOne(customerId);
            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
