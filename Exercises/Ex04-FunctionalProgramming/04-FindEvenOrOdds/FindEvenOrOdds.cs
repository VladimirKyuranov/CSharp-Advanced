using System;
using System.Linq;

class FindEvenOrOdds
{
    static void Main(string[] args)
    {
        int[] range = Console.ReadLine()
            .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var numbers = Enumerable.Range(range[0], range[1] - range[0] + 1);
        string condition = Console.ReadLine();
        var evenOdd = EvenOrOdd(condition);

        Console.WriteLine(string.Join(" ", numbers.Where(evenOdd)));
    }

    static Func<int, bool> EvenOrOdd(string condition)
    {
        if (condition == "even")
        {
            return n => n % 2 == 0;
        }
        else
        {
            return n => n % 2 != 0;
        }
    }
}