Console.WriteLine("Please write index Number...");

 int indexNumber = int.Parse(Console.ReadLine()); 

int firstNumber = 1; 

int i = 0;

while (indexNumber > i)
{
   

     if (indexNumber == 2)
    {
        //primeNumber
        Console.WriteLine(firstNumber);
    }
    else if (firstNumber % 2 == 0)
    {
      firstNumber++;
    }
    else
    {
        int divisor = 3;

        bool Prime = true;

        while (divisor < firstNumber)
        {
            if (firstNumber % divisor == 0)
            {
                Prime = false;
                firstNumber++;
                //notPrimeNumber
                break;
            }
            divisor += 2;
        }
        if (Prime)
        {
            firstNumber++;
            i++;
            //primeNumber
        }
        
    }
   if (indexNumber == i)
    {
  firstNumber--;
        Console.WriteLine("Prime number is " + firstNumber);
    }
}

Console.ReadLine();

