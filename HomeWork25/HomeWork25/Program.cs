                        1.
class Program
{
    static void Main()
    {
        var evenTask = Task.Run(() => PrintEvenNumbers());
        var oddTask = Task.Run(() => PrintOddNumbers());

        Task.WhenAll(evenTask, oddTask).Wait();
    }

    static void PrintEvenNumbers()
    {
        for (int i = 2; i <= 20; i += 2)
        {
            Console.WriteLine($"Even: {i}");
            Thread.Sleep(100); 
        }
    }

    static void PrintOddNumbers()
    {
        for (int i = 1; i <= 19; i += 2)
        {
            Console.WriteLine($"Odd: {i}");
            Thread.Sleep(100); 
        }
    }
}



                        2.

using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static AutoResetEvent eventA = new AutoResetEvent(true);
    static AutoResetEvent eventB = new AutoResetEvent(false);
    static AutoResetEvent eventC = new AutoResetEvent(false);

    static void Main()
    {
        var taskA = Task.Run(() => PrintA());
        var taskB = Task.Run(() => PrintB());
        var taskC = Task.Run(() => PrintC());

        Task.WhenAll(taskA, taskB, taskC).Wait();
    }

    static void PrintA()
    {
        for (int i = 0; i < 10; i++)
        {
            eventA.WaitOne();
            Console.Write("A ");
            Thread.Sleep(100); // Simulate work
            eventB.Set();
        }
    }

    static void PrintB()
    {
        for (int i = 0; i < 10; i++)
        {
            eventB.WaitOne();
            Console.Write("B ");
            Thread.Sleep(100); // Simulate work
            eventC.Set();
        }
    }

    static void PrintC()
    {
        for (int i = 0; i < 10; i++)
        {
            eventC.WaitOne();
            Console.Write("C ");
            Thread.Sleep(100); // Simulate work
            eventA.Set();
        }
    }
}
