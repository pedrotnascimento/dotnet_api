#nullable disable
using System;
using System.Collections.Generic;

namespace PedroApi.Models
{
    public partial class OrderProducts
    {
        public long OrderProductId { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public long Quantity { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Products Product { get; set; }
    }
}