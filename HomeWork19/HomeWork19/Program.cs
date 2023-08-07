using System;
using System.Collections.Generic;

class LargeNumber
{
    private string value;
    private bool isNegative;

    public LargeNumber(string number)
    {
        isNegative = false;
        value = number.TrimStart('0');
        if (value == "")
        {
            value = "0";
        }
        if (value.StartsWith("-"))
        {
            isNegative = true;
            value = value.TrimStart('-');
        }
    }

    public static LargeNumber Add(LargeNumber num1, LargeNumber num2)
    {
        if (num1.isNegative && !num2.isNegative)
        {
            return Subtract(num2, new LargeNumber(num1.value));
        }
        if (!num1.isNegative && num2.isNegative)
        {
            return Subtract(num1, new LargeNumber(num2.value));
        }

        string result = AddNumbers(num1.value, num2.value);
        return new LargeNumber(result) { isNegative = num1.isNegative };
    }

    public static LargeNumber Subtract(LargeNumber num1, LargeNumber num2)
    {
        if (num1.isNegative && !num2.isNegative)
        {
            return Add(new LargeNumber("-" + num1.value), num2);
        }
        if (!num1.isNegative && num2.isNegative)
        {
            return Add(num1, new LargeNumber("-" + num2.value));
        }
        if (IsLessThan(num1.value, num2.value))
        {
            string result = SubtractNumbers(num2.value, num1.value);
            return new LargeNumber(result) { isNegative = true };
        }
        else
        {
            string result = SubtractNumbers(num1.value, num2.value);
            return new LargeNumber(result) { isNegative = false };
        }
    }

    private static bool IsLessThan(string num1, string num2)
    {
        if (num1.Length < num2.Length)
            return true;
        if (num1.Length > num2.Length)
            return false;

        for (int i = 0; i < num1.Length; i++)
        {
            if (num1[i] < num2[i])
                return true;
            else if (num1[i] > num2[i])
                return false;
        }

        return false;
    }

    private static string AddNumbers(string num1, string num2)
    {
        int maxLength = Math.Max(num1.Length, num2.Length);
        num1 = num1.PadLeft(maxLength, '0');
        num2 = num2.PadLeft(maxLength, '0');

        int carry = 0;
        string result = "";

        for (int i = maxLength - 1; i >= 0; i--)
        {
            int sum = (num1[i] - '0') + (num2[i] - '0') + carry;
            carry = sum / 10;
            result = (sum % 10) + result;
        }

        if (carry > 0)
        {
            result = carry + result;
        }

        return result;
  
}

    private static string SubtractNumbers(string num1, string num2)
    {
        int maxLength = Math.Max(num1.Length, num2.Length);
        num1 = num1.PadLeft(maxLength, '0');
        num2 = num2.PadLeft(maxLength, '0');

        int borrow = 0;
        string result = "";

        for (int i = maxLength - 1; i >= 0; i--)
        {
            int digit1 = num1[i] - '0' - borrow;
            int digit2 = num2[i] - '0';

            if (digit1 < digit2)
            {
                borrow = 1;
                digit1 += 10;
            }
            else
            {
                borrow = 0;
            }

            int difference = digit1 - digit2;
            result = difference + result;
        }

        return result.TrimStart('0');
    }

    public override string ToString()
    {
        if (isNegative)
            return "-" + value;
        return value;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<LargeNumber> numbers = new List<LargeNumber>();
        while (true) 
            {
            Console.WriteLine("Enter just large numbers for one per line, type '=' when finished:");
            while (true)
            {
                string input = Console.ReadLine();
                    if (input.ToLower() == "=")
                    break;

                LargeNumber num = new LargeNumber(input);
                numbers.Add(num);
             }

            LargeNumber sum = numbers[0];
            LargeNumber difference = numbers[0];

        for (int i = 1; i < numbers.Count; i++)
        {
            sum = LargeNumber.Add(sum, numbers[i]);
            difference = LargeNumber.Subtract(difference, numbers[i]);
        }

        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Difference: {difference}");
        }
    }
}
