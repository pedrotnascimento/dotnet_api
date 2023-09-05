using PedroApi.Models;

namespace PedroApi.DTO
{
    public class OrderDto
    {
        public OrderDto()
        {
            OrderProducts = new HashSet<OrderProducts>();
        }

        public long OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public long CustomerId { get; set; }

        public virtual CustomerDto Customer { get; set; }
        public virtual ICollection<OrderProducts> OrderProducts { get; set; }


        public double GetTotalCost()
        {
            var totalCost = OrderProducts.Select(x => x.Quantity * x.Product.Price).Sum();
            return totalCost;

        }

    }
}
