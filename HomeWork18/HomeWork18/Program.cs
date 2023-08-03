using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Enter an arithmetic expression (or 'exit' to quit):");
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
                break;

            try
            {
                double result = EvaluateExpression(input);
                Console.WriteLine("Result: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    static double EvaluateExpression(string expression)
    {
        Queue<string> postfixQueue = ConvertToPostfix(expression);
        Stack<double> operandStack = new Stack<double>();

        while (postfixQueue.Count > 0)
        {
            string token = postfixQueue.Dequeue();

            if (IsNumber(token))
            {
                operandStack.Push(double.Parse(token));
            }
            else if (IsOperator(token))
            {
                double b = operandStack.Pop();
                double a = operandStack.Pop();

                switch (token)
                {
                    case "+":
                        operandStack.Push(a + b);
                        break;
                    case "-":
                        operandStack.Push(a - b);
                        break;
                    case "*":
                        operandStack.Push(a * b);
                        break;
                    case "/":
                        if (b == 0)
                            throw new DivideByZeroException("Division by zero is not allowed.");
                        operandStack.Push(a / b);
                        break;
                    default:
                        throw new ArgumentException("Invalid operator: " + token);
                }
            }
        }

        if (operandStack.Count != 1)
            throw new ArgumentException("Invalid expression.");

        return operandStack.Pop();
    }

    static Queue<string> ConvertToPostfix(string infixExpression)
    {
        Queue<string> postfixQueue = new Queue<string>();
        Stack<string> operatorStack = new Stack<string>();

        foreach (string token in Tokenize(infixExpression))
        {
            if (IsNumber(token))
            {
                postfixQueue.Enqueue(token);
            }
            else if (IsOperator(token))
            {
                while (operatorStack.Count > 0 && Precedence(operatorStack.Peek()) >= Precedence(token))
                {
                    postfixQueue.Enqueue(operatorStack.Pop());
                }
                operatorStack.Push(token);
            }
            else if (token == "(")
            {
                operatorStack.Push(token);
            }
            else if (token == ")")
            {
                while (operatorStack.Count > 0 && operatorStack.Peek() != "(")
                {
                    postfixQueue.Enqueue(operatorStack.Pop());
                }
                if (operatorStack.Count == 0 || operatorStack.Peek() != "(")
                    throw new ArgumentException("Unbalanced parentheses.");
                operatorStack.Pop(); 
            }
            else
            {
                throw new ArgumentException("Invalid token: " + token);
            }
        }

        while (operatorStack.Count > 0)
        {
            if (operatorStack.Peek() == "(" || operatorStack.Peek() == ")")
                throw new ArgumentException("Unbalanced parentheses.");
            postfixQueue.Enqueue(operatorStack.Pop());
        }

        return postfixQueue;
    }

    static IEnumerable<string> Tokenize(string expression)
    {
        expression = expression.Replace(" ", ""); 

        for (int i = 0; i < expression.Length; i++)
        {
            char c = expression[i];

            if (char.IsDigit(c) || c == '.')
            {
                int startIndex = i;
                while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == '.'))
                {
                    i++;
                }
                yield return expression.Substring(startIndex, i - startIndex);
                i--; 
            }
            else if (c == '+' || c == '-' || c == '*' || c == '/' || c == '(' || c == ')')
            {
                yield return c.ToString();
            }
            else
            {
                throw new ArgumentException("Invalid character: " + c);
            }
        }
    }

    static bool IsNumber(string token)
    {
        return double.TryParse(token, out _);
    }

    static bool IsOperator(string token)
    {
        return token == "+" || token == "-" || token == "*" || token == "/";
    }

    static int Precedence(string op)
    {
        if (op == "+" || op == "-")
            return 1;
        else if (op == "*" || op == "/")
            return 2;
        else
            return 0;
    }
}
