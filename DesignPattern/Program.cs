using DesignPattern.AbstractFactory;
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

FighterFactory factory = new Mig29FighterFactory();

Fighter fighter = factory.CreateFighter();
Missile missile = factory.CreateMissile();
Bomb bomb = factory.CreateBomb();


void TestFighter(FighterFactory factory)
{
    Fighter fighter = factory.CreateFighter();
    Missile missile = factory.CreateMissile();
    Bomb bomb = factory.CreateBomb();
    Console.WriteLine($"Testing {fighter.GetType().Name} with {missile.GetType().Name} and {bomb.GetType().Name}");
}