Console.WriteLine("Please write number...");
int number = int.Parse(Console.ReadLine());

string notprimenumber = (number + " is NOT a prime number");
string primenumber = (number + " is a prime number");

if (number < 2)
{
    Console.WriteLine(notprimenumber);
}
else if (number == 2)
{
    Console.WriteLine(primenumber);
}
else if (number % 2 == 0)
{
    Console.WriteLine(notprimenumber);

}
else
{
    int divisor = 3;
    bool Prime = true;
    while (divisor < number)
    {
        if (number % divisor == 0)
        {
            Prime = false;
            Console.WriteLine(notprimenumber);
            break;
        }
        divisor += 2;
    }
    if (Prime)
    {
        Console.WriteLine(primenumber);
    }
}
