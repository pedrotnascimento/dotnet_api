using PedroApi.Models;

namespace PedroApi.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public CustomerRepository() { }

        public Customers? FindOne(long customerId)
        {
            Customers? customers = null;
            using (var context = new OrderApiDatabasedbContext())
            {
                customers = context.Customers.FirstOrDefault(x => x.CustomerId == customerId);
            }
            return customers;
        }
    }
}
