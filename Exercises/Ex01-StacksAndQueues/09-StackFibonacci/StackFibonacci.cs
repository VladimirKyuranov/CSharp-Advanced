using System;
using System.Collections.Generic;

class StackFibonacci
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());

        Stack<long> fibonacci = new Stack<long>();
        long firstNumber = 0;

        fibonacci.Push(0);
        fibonacci.Push(1);

        for (int currentNumber = 2; currentNumber <= number; currentNumber++)
        {
            long temp = fibonacci.Peek();
            fibonacci.Push(firstNumber + temp);
            firstNumber = temp;
        }

        Console.WriteLine(fibonacci.Peek());        
    }
}