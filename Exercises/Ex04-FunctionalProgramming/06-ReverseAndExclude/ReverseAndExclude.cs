using System;
using System.Collections.Generic;
using System.Linq;

class ReverseAndExclude
{
    static void Main(string[] args)
    {
        List<int> numbers = Console.ReadLine()
            .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();
        int divisor = int.Parse(Console.ReadLine());
        var filter = Filter(divisor);

        Console.WriteLine(string.Join(" ", numbers.Where(filter).Reverse()));
    }

    static Func<int, bool> Filter(int divisor)
    {
        return x => x % divisor != 0;
    }
}