using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BuilderExample
{
    public class IceCreamBuilder
    {
        private IceCream _iceCream;
        public IceCreamBuilder()
        {
            _iceCream = new IceCream();
        }

        public void AppToppings(string toppings)
        {
            // Add toppings to the ice cream
        }
        public void SetFlavour(string flavour)
        {
            // Add flavour to the ice cream
        }
        public IceCream Make()
        {
            return _iceCream;
        }
    }
}
