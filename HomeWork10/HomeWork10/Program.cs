using System;


public abstract class Car
{
    protected int speed;

    public abstract void Accelerate();
    public abstract void Brake();

    public int GetSpeed()
    {
        return speed;
    }
}

public class BMW : Car
{
    public override void Accelerate()
    {
        speed += 19;
        if (speed >= 310)
        {
            speed = 310;
        }
    }

    public override void Brake()
    {
        speed -= 5;
        if (speed < 0)
        {
            speed = 0; 
        }
    }
}


public class AUDI : Car
{
    public override void Accelerate()
    {
        speed += 17;
        if (speed >= 290)
        {
            speed = 290;
        }
    }

    public override void Brake()
    {
        speed -= 4; 
        if (speed < 0)
        {
            speed = 0; 
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car bmw = new BMW();
        Car audi = new AUDI();
        Console.WriteLine("Choose car: 1-BMW or 2-Audi ");
        string N = Console.ReadLine();
        Console.WriteLine();
            
        
        while (true)
        {



            if (N == "1")
            {
                Console.WriteLine("Choose action: 1-Accelerate or 2-Brake (3-Change car) ");

                string B = Console.ReadLine();
                Console.WriteLine();
                if (B == "1")
                {
                    bmw.Accelerate();
                    Console.WriteLine("The speed of BMW: " + bmw.GetSpeed());
                    Console.WriteLine();
                }
                if (B == "2")
                {
                    bmw.Brake();
                    Console.WriteLine("The speed of BMW: " + bmw.GetSpeed());
                    Console.WriteLine();
                }
                if (B == "3")
                {
                    N = null;
                    bmw = new BMW();
                    Console.WriteLine("Choose car: 1-BMW or 2-Audi ");
                    N = Console.ReadLine();
                }
            }
            else if (N == "2")
            {
                Console.WriteLine();
                Console.WriteLine("Choose action: 1-Accelerate or 2-Brake (3-Change car)");

                string F = Console.ReadLine();
                if (F == "1")
                {
                    audi.Accelerate();
                    Console.WriteLine("The speed of Audi: " + audi.GetSpeed());
                    Console.WriteLine();
                }
                else if (F == "2")
                {
                    audi.Brake();
                    Console.WriteLine("The speed of Audi: " + audi.GetSpeed());
                    Console.WriteLine();
                }
                if (F == "3")
                {
                    N = null;
                    audi = new AUDI();
                    Console.WriteLine("Choose car: 1-BMW or 2-Audi ");
                    N = Console.ReadLine();
                }
            }
            else if (N != "1" && N != "2")
            {
                N = null;
                Console.WriteLine("Choose car: 1-BMW or 2-Audi ");
                N = Console.ReadLine();
            }
        }
    }
}
