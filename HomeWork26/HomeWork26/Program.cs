using System;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Enumerable.Range(1, 1000000).ToArray();
        long sum = 0;

 
        int numThreads = args.Length > 0 ? int.Parse(args[0]) : Environment.ProcessorCount;

        Console.WriteLine($"Calculating with {numThreads} threads.");

        var watch = System.Diagnostics.Stopwatch.StartNew();

        sum = CalculateSumParallel(numbers, numThreads);

        watch.Stop();
        Console.WriteLine($"Sum (Parallel): {sum}");
        Console.WriteLine($"Time taken (Parallel): {watch.ElapsedMilliseconds} ms");


        watch = System.Diagnostics.Stopwatch.StartNew();

        sum = CalculateSumSequential(numbers);

        watch.Stop();
        Console.WriteLine($"Sum (Sequential): {sum}");
        Console.WriteLine($"Time taken (Sequential): {watch.ElapsedMilliseconds} ms");
    }

    static long Calculate(int number)
    {
        return (long)number * number;
    }

    static long CalculateSumSequential(int[] numbers)
    {
        long sum = 0;
        foreach (int number in numbers)
        {
            sum += Calculate(number);
        }
        return sum;
    }

    static long CalculateSumParallel(int[] numbers, int numThreads)
    {
        long sum = 0;

        Parallel.ForEach(numbers, new ParallelOptions { MaxDegreeOfParallelism = numThreads }, number =>
        {
            long square = Calculate(number);
            Interlocked.Add(ref sum, square);
        });

        return sum;
    }
}
