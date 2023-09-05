namespace PedroApi.ViewModels
{
    public class OrderCollectionGet
    {
        public long OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public long CustomerId { get; set; }
        public double Total { get; set; } = 0;
        public List<OrderProductGet> LineItems { get; set; } = new List<OrderProductGet>();

    }

    public class OrderProductGet
    {
        public long ProductId { get; set;}
        public string ProductName { get; set; } = "";
        public double QuantityPurchased { get; set; }
        public double TotalCost { get; set; }
    }
}
