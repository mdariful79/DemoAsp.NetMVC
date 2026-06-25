using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Practice.Delegation
{
    public class Report
    {
        public void Show(Order order)
        {
            
            Console.WriteLine($"Price: {order.TotalPrice}");
        }
    }
}
