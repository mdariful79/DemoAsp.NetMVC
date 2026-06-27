using DesignPattern.BuilderExample;
using DesignPattern.PrototypeExample;
using System.Runtime.ConstrainedExecution;

Console.WriteLine("Hello, World!");
Product product1 = new Product { Name = "Product 1", Price = 10.0 };
Product product2 = new Product
{
    Name = product1.Name,
    Price = product1.Price
};
Product product3 = product1.Copy();

IceCreamBuilder iceCreamBuilder = new IceCreamBuilder();
iceCreamBuilder.SetFlavour("Vanilla");
iceCreamBuilder.AppToppings("Chocolate Chips");
IceCream iceCream = iceCreamBuilder.Make();
Console.WriteLine($"Ice Cream: {iceCream.Flavour} with {iceCream.Toppings}");