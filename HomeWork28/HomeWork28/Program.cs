using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
class Program
{
    static void Main(string[] args)
    {
        int numberOfThreads = Environment.ProcessorCount; 
        if (args.Length > 0 && int.TryParse(args[0], out int customThreadCount))
        {
            numberOfThreads = customThreadCount;
        }

        Console.WriteLine($"Using {numberOfThreads} threads");

        int[] numbers = Enumerable.Range(1, 100000000).ToArray();

        var stopwatch = Stopwatch.StartNew();

        var result = numbers.AsParallel()
            .WithDegreeOfParallelism(numberOfThreads)
            .Where(x => x % 2 == 0)
            .Select(x => x * x)
            .ToList();

        stopwatch.Stop();

        Console.WriteLine($"Result: {result.Count}");
        Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");
    }
}