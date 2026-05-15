using LinqExample;

List<Order> orders = new List<Order>();
List<Customer> customers = new List<Customer>();
List<Product> products = new List<Product>();

// Joining example
var result = from o in orders
             join c in customers on o.CustomerId equals c.CustomerId
             select new
             {
                 TotalProducts = o.Products.Count(), CustomerName = c.CustomerName
             };
// Grouping example
int[] numbers = { 9, 2, 53, 11, 95, 13, 99, 64 };

var numberGroup = from n in numbers
                  group n by n % 2 != 0 into g
                  select new { IsOdd = g.Key, Numbers = g.ToList() };
                   
Console.WriteLine("Odd numbers:");
foreach (var group in numberGroup)
{
    if (group.IsOdd)
    {
        foreach (var number in group.Numbers)
        {
            Console.WriteLine(number);
        }
    }
}