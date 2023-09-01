using PedroApi.DTO;
using PedroApi.Models;

namespace PedroApi.Services
{
    public interface ICustomerService
    {
        CustomerDto? FindCustomer(long customerId);
    }
}