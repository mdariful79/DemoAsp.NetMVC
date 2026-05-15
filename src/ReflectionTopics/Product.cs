using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectionTopics
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public string Description { get; set; }

        public double GetDiscountedPrice()
        {
            return Price * 0.9; // 10% discount
        }



        /*
         * name: null,
         * price: 0.0,
         * description: null
         * 
         * 
         * 
         * 
         */
    }
    class Dog
    {
        public string Name = "Buddy";
        public void Bark() => Console.WriteLine("Woof!");
        private void Secret() => Console.WriteLine("I ate the homework");
    }
}
