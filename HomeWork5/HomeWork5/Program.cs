const int N = 10;

int[] array = new int[N];

Console.WriteLine("Please write 10 numbers in array: ");

for (int i = 0; i < N; i++)
{
    array[i] = int.Parse(Console.ReadLine());
}

Console.WriteLine("Result array:");

foreach (int i in array)
{
    Console.WriteLine(i);
}

Console.WriteLine("This is flip array: "); 

for (int i = 0;i < N;i++)
{
    Console.WriteLine(array[array.Length - 1 - i] + " ");
}

Console.WriteLine("Write the number what you want to check in the array: ");

int checkNumber = int.Parse(Console.ReadLine());

for (int i = 0; i < array.Length; i++)
{
    if (array[i] == checkNumber)
    {
        Console.WriteLine("Your number: " + checkNumber);
        Console.WriteLine("The position of this number in the array is: " + i);
        return i;
    }
}
Console.WriteLine("Your number: " + checkNumber);
Console.WriteLine("This number isn't in the array!!!");
return -1;

Console.ReadLine();