using Microsoft.EntityFrameworkCore;
using PedroApi.Models;

namespace PedroApi.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public OrderRepository() { }

        public List<Orders> FindByCustomerAndDateInterval(long customerId, DateTime startDate, DateTime endDate)
        {
            List<Orders> orders = new List<Orders>();
            using (var context = new OrderApiDatabasedbContext())
            {
                orders = context.Orders
                    .Where(x => x.CustomerId == customerId
                            && startDate.Date <= x.OrderDate.Date
                            && x.OrderDate.Date <= endDate.Date)
                    .Include(x=> x.OrderProducts).ThenInclude(x=> x.Product)
                    .ToList();
            }
            return orders;
        }

        public void SaveOrder(Orders result)
        {
            using (var context = new OrderApiDatabasedbContext())
            {
                context.Orders.Add(result);
                context.SaveChanges();
            }
        }
    }
}
