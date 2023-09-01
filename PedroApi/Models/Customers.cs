#nullable disable
using System;
using System.Collections.Generic;

namespace PedroApi.Models
{
    public  class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public long CustomerId { get; set; }
        public string Name { get; set; }
        public float Balance { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}