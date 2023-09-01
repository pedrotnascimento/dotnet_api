using PedroApi.Models;

namespace PedroApi.Repositories
{
    public interface ICustomerRepository
    {
        Customers? FindOne(long customerId);
    }
}