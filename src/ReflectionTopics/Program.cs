using ReflectionTopics;
using System.Reflection;

Type t;

Assembly a; // collection of Type

Type tp = typeof(Product);
Type ti = typeof(int);


MethodInfo[] methods = tp.GetMethods();

//foreach (var method in methods)
//    Console.WriteLine($"Method Name: {method.Name}");

//FieldInfo[] fields = tp.GetFields();
//foreach (var field in fields)
//{
//    Console.WriteLine($"Field Name: {field.Name}");
//}

MethodInfo myMethod = tp.GetMethod("GetDiscountedPrice");

ConstructorInfo constructor = tp.GetConstructor(new Type[] {});
PropertyInfo property = tp.GetProperty("Price");


object o = constructor.Invoke(new object[] { });
property.SetValue(o, 100);

object result = myMethod.Invoke(o, new object[] { });
Console.WriteLine($"Discounted Price: {result}");




Type t1 = typeof(Dog);

foreach (var method in t1.GetMethods())
    Console.WriteLine(method.Name);

// Output: Bark, ToString, GetType, Equals...

