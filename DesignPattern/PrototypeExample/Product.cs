using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.PrototypeExample
{
    public class Product : ICloneable
    {
        public string Name { get; set; }
        public double Price { get; set; }
        // This is a c# interface that allows you to create a copy of an object.
        // The Clone method is used to create a new instance of the object with the same values as the original object.
        public object Clone()
        {
            throw new NotImplementedException();
        }

        // 20 other properties

        public Product Copy()
        {
            return new Product
            {
                Name = Name,
                Price = Price
                //copy other properties
            };
        }
    }
}
