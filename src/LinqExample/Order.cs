using System;
using System.Collections.Generic;
using System.Text;

namespace LinqExample
{
    public class Order
    {
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public int CustomerId { get; set; }
    }
}
