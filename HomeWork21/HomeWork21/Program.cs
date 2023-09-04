using System;
using System.Collections.Generic;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        var evenNumbers = numbers.Where(n => n % 2 == 0);
        Console.WriteLine("Even numbers:");
        foreach (var number in evenNumbers)
        {
            Console.WriteLine(number);
        }
        Console.WriteLine();

        var sortedNumbers = numbers.OrderByDescending(n => n);
        Console.WriteLine("The numbers are in reverse order:");
        foreach (var number in sortedNumbers)
        {
            Console.WriteLine(number);
        }
        Console.WriteLine();

        var firstNumberGreaterThan5 = numbers.FirstOrDefault(n => n > 5);
        Console.WriteLine("The first number is greater than 5: " + firstNumberGreaterThan5);
        Console.WriteLine();

        var groupedNumbers = numbers.GroupBy(n => n % 3);
        Console.WriteLine("Groups of numbers by the remainder of division by 3:");
        foreach (var group in groupedNumbers)
        {
            Console.WriteLine("Remainder " + group.Key + ": " + string.Join(", ", group));
        }
        Console.WriteLine();

        var sum = numbers.Sum();
        Console.WriteLine($"The sum of all numbers: {sum}");
        Console.WriteLine();

        var between5And8 = numbers.Where(num => num > 5 && num < 8).FirstOrDefault();
        Console.WriteLine($"The number is greater than 5 and less than 8: {between5And8}");
        Console.WriteLine();
    }
}
