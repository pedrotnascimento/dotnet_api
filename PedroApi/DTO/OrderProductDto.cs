using PedroApi.Models;

namespace PedroApi.DTO
{
    public class OrderProductDto
    {
        public long OrderProductId { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public long Quantity { get; set; }
        public virtual OrderDto Order { get; set; }
        public virtual ProductDto Product { get; set; }

        public string GetProductName()
        {
            return Product.Name;
        }

        public double GetProductTotalCost()
        {
            return Product.Price * Quantity;
        }
    }
}
