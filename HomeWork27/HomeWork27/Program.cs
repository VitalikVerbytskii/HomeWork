class Program
{
    static async Task Main(string[] args)
    {
        int input = 10;

        Console.WriteLine("Asynchronous Calculation Started");
        Task<int> task = CalculateAsync(input);

        int result = await task;

        Console.WriteLine($"Result: {result}");
    }

    static async Task<int> CalculateAsync(int number)
    {

        await Task.Delay(1000); 

        int square = number * number;
        return square;
    }
}
