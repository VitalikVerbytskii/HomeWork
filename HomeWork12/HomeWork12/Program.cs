namespace HomeWork12 { 
using System.Diagnostics;

public class SortAlgorithm
{
    // без 
    public static void InsertionSortWithout(int[] array)
    {
        int n = array.Length;
        for (int i = 1; i < n; i++)
        {
            int key = array[i];
            int j = i - 1;
            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = key;
        }
    }
    public static void InsertionSortWith<T>(T[] array) where T : IComparable<T>
    {
        int n = array.Length;
        for (int i = 1; i < n; i++)
        {
            T key = array[i];
            int j = i - 1;
            while (j >= 0 && array[j].CompareTo(key) > 0)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = key;
        }
    }
        static void Main(string[] args)
    {
        
        while (true) {
        Console.WriteLine("Please write 5 numbers in array: ");
        Console.WriteLine();
        
        int[] array = new int[5];
            
            

            for (int i = 0; i < 5; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        InsertionSortWithout(array);
        stopwatch.Stop();
        TimeSpan elapsedTime = stopwatch.Elapsed;
        Console.WriteLine("Runtime without using generic types: " + elapsedTime);
        Console.WriteLine();

        
        stopwatch.Start();
        InsertionSortWith(array);
        stopwatch.Stop();
        TimeSpan elapsedTim2 = stopwatch.Elapsed;
        Console.WriteLine("Runtime with using generic types:: " + elapsedTim2);

        
        }
    }
}

}