using PedroApi.Models;

namespace PedroApi.Services
{
    public interface ICustomerService
    {
        Customers? FindCustomer(long customerId);
    }
}