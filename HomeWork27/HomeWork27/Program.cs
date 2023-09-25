using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        int inputNumber = 10;
        Console.WriteLine("Calculating square asynchronously...");

        
        Task<int> task = CalculateAsync(inputNumber);

        Console.WriteLine("Task started");


        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Working on other tasks ({i + 1}/5)");
            await Task.Delay(1000); 
        }

        int result = await task;

        Console.WriteLine("Result: " + result);
    }

    static async Task<int> CalculateAsync(int number)
    {
        
        await Task.Delay(2000); 
        return number * number;
    }
}
