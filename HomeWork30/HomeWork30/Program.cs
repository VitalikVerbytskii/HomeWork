using System;

class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("Enter the number of rows:");
        if (!int.TryParse(Console.ReadLine(), out int numberOfStrings))
        {
            Console.WriteLine("Incorrect entry of the number of lines");
            return;
        }

        string[] strings = new string[numberOfStrings];
        for (int i = 0; i < numberOfStrings; i++)
        {
            Console.WriteLine($"Enter a string #{i + 1}:");
            strings[i] = Console.ReadLine();
        }

        MyObject obj = new MyObject();
        obj.Run(strings);
    }
}

class MyObject
{
    public unsafe void Run(string[] data)
    {
        MyOtherObject otherObj = new MyOtherObject(data);
        ((IDisposable)otherObj).Dispose();
    }
}

class MyOtherObject : IDisposable
{
    private string[] data;

    public MyOtherObject(string[] data)
    {
        this.data = data;
    }

    unsafe void IDisposable.Dispose()
    {
        Console.WriteLine($"The number of elements in the array: {data.Length}");
        foreach (var item in data)
        {
            Console.WriteLine(item);
        }

        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine("The object MyOtherObject has been deleted");

        fixed (char* firstChar = data[0])
        {
            char* currentChar = firstChar;
            while (*currentChar != '\0')
            {
                Console.Write(*currentChar);
                currentChar++;
            }
        }
    }
}
