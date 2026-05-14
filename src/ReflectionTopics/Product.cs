using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectionTopics
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public double GetDiscountedPrice(double discountPercentage)
        {
            return Price - (Price * discountPercentage / 100);
        }


    }
}
