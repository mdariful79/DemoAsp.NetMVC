using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Practice.Delegation
{
    public class Order
    {
        public double Price { get; set; }
        public double ValueAddedTax { get; set; }

        public double TotalPrice()
        {
            return Price + ValueAddedTax;
        }
    }
}
