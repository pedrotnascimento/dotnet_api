#nullable disable
using System;
using System.Collections.Generic;

namespace PedroApi.Models
{
    public partial class Products
    {
        public Products()
        {
            OrderProducts = new HashSet<OrderProducts>();
        }

        public long ProductId { get; set; }
        public string Name { get; set; }
        public byte[] Price { get; set; }
        public long Quantity { get; set; }

        public virtual ICollection<OrderProducts> OrderProducts { get; set; }
    }
}