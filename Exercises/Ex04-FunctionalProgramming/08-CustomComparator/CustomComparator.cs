using System;
using System.Collections.Generic;
using System.Linq;

class CustomComparator
{
    static void Main(string[] args)
    {
        List<int> numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        List<int> sortedNumbers = new List<int>();
        var evenFilter = Even();
        var oddFilter = Odd();

        sortedNumbers.AddRange(evenFilter(numbers));
        sortedNumbers.AddRange(oddFilter(numbers));

        string result = string.Join(" ", sortedNumbers);

        Console.WriteLine(result);
    }

    static Func<List<int>, List<int>> Even()
    {
        return x => x.Where(n => n % 2 == 0).OrderBy(n => n).ToList();
    }

    static Func<List<int>, List<int>> Odd()
    {
        return x => x.Where(n => n % 2 != 0).OrderBy(n => n).ToList();
    }
}