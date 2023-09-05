using PedroApi.Models;

namespace PedroApi.Repositories
{
    public interface IOrderRepository
    {
        List<Orders> FindByCustomerAndDateInterval(long customerId, DateTime startDate, DateTime endDate);
        void SaveOrder(Orders result);
    }
}