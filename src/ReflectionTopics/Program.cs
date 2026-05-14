using ReflectionTopics;
using System.Reflection;

Type t;
Assembly a;

Type tp = typeof(Product);
MethodInfo[] methods = tp.GetMethods();
foreach (var method in methods)
{
    Console.WriteLine($"Method Name: {method.Name}");
}
