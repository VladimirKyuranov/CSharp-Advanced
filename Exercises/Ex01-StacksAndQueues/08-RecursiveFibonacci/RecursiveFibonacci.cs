using System;
using System.Collections.Generic;

class RecursiveFibonacci
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());

        var fibonacci = new Dictionary<long, long>();

        fibonacci.Add(1, 1);
        fibonacci.Add(2, 1);

        for (int currentNumber = 3; currentNumber <= number; currentNumber++)
        {
            long firtsNumber = fibonacci[currentNumber - 2];
            long secondNumber = fibonacci[currentNumber - 1];
            fibonacci.Add(currentNumber, firtsNumber + secondNumber);
        }

        Console.WriteLine(fibonacci[number]);
    }
}