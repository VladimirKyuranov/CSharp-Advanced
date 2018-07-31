using System;
using System.Linq;

class CustomMinFunction
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine()
            .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Func<int[], int> MinNumber = n => n.Min();

        Console.WriteLine(MinNumber(numbers));
    }
}