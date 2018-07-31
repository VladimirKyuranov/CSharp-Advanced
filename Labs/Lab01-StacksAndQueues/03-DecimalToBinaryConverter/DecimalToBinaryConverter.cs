using System;
using System.Collections.Generic;

class DecimalToBinaryConverter
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());

        Stack<int> stack = new Stack<int>();

        while (number > 0)
        {
            stack.Push(number % 2);
            number /= 2;
        }

        if (stack.Count > 0)
        {
            Console.WriteLine(string.Join("", stack));
        }
        else
        {
            Console.WriteLine(0);
        }
    }
}