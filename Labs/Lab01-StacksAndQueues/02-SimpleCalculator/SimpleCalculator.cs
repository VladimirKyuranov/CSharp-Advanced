using System;
using System.Collections.Generic;
using System.Linq;

class SimpleCalculator
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine()
            .Split();

        Stack<string> stack = new Stack<string>(input.Reverse());

        while (stack.Count > 1)
        {
            int firstOperand = int.Parse(stack.Pop());
            string operation = stack.Pop();
            int secondOperand = int.Parse(stack.Pop());

            if (operation == "-")
            {
                stack.Push((firstOperand - secondOperand).ToString());
            }
            else
            {
                stack.Push((firstOperand + secondOperand).ToString());
            }
        }

        Console.WriteLine(stack.Pop());
    }
}