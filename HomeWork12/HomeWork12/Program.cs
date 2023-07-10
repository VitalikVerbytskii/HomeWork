using System;
using System.Diagnostics;

public class SortAlgorithm
{
    // без 
    public static void InsertionSort(int[] array)
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
    public static void InsertionSort<T>(T[] array) where T : IComparable<T>
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
        int[] array = { 5, 2, 4, 6, 1, 3 };

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        InsertionSort(array);
        stopwatch.Stop();

        TimeSpan elapsedTime = stopwatch.Elapsed;
        Console.WriteLine("Час виконання: " + elapsedTime);

        Console.ReadLine();
    }
}

