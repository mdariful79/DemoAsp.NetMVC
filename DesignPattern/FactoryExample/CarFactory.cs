using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.FactoryExample
{
    public class CarFactory
    {
        public Car CreateCar(string brand)
        {
            if (brand == "toyota")
            {
                return new Car { Model = "Camry", Color = "Red", Speed = 120  };

            }
            else if (brand == "honda")
            {
                return new Car { Model = "Civic",Color="Black", Speed = 110};
            }
            return new Car();
        }
    }
}
