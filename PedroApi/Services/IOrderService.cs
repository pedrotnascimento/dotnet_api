using PedroApi.ViewModels;
using PedroApi.DTO;

namespace PedroApi.Services
{
    public interface IOrderService
    {
        OrderDto CreateOrder(OrderCreate orderCreate);
        List<OrderDto> FindByCustomerAndDateInterval(long customerId, DateTime startDate, DateTime endDate);
    }
}