namespace PedroApi.ViewModels
{
    public class OrderCreate
    {

        public long CustomerId { get; set; }
        public List<OrderProductCreate> Products { get; set; } = new List<OrderProductCreate>();

    }

    public class OrderProductCreate
    {
        public long ProductId { get; set; }
        public long Quantity { get; set; }
    }
}
