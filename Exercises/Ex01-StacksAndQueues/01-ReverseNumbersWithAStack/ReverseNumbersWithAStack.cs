using System;
using System.Collections.Generic;
using System.Linq;

class ReverseNumbersWithAStack
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine()
            .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Stack<int> stackNumbers = new Stack<int>(numbers);

        Console.WriteLine(string.Join(" ", stackNumbers));
    }
}