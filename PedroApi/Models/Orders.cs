#nullable disable
using System;
using System.Collections.Generic;

namespace PedroApi.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderProducts = new HashSet<OrderProducts>();
        }

        public long OrderId { get; set; }
        public byte[] OrderDate { get; set; }
        public long CustomerId { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual ICollection<OrderProducts> OrderProducts { get; set; }
    }
}