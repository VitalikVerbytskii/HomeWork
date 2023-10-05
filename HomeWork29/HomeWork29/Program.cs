using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        MyClass obj = new MyClass();

       
        string methodName;
        if (args.Length > 0)
        {
            methodName = args[0];
        }
        else
        {
            Console.Write("Enter a method name (Print): ");
            methodName = Console.ReadLine();
        }

        MethodInfo method = typeof(MyClass).GetMethod(methodName);
        if (method != null)
        {
            method.Invoke(obj, new object[] { "Hello World" });
        }
        else
        {
            Console.WriteLine("Method not found.");
        }
    }
}

class MyClass
{
    public void Print(string message)
    {
        Console.WriteLine(message);
    }
}
