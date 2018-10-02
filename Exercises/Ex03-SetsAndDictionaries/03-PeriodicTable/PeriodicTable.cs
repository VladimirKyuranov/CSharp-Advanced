using System;
using System.Collections.Generic;
using System.Linq;

class PeriodicTable
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());
        HashSet<string> table = new HashSet<string>();

        for (int counter = 0; counter < count; counter++)
        {
            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(e => table.Add(e));
        }

        Console.WriteLine(string.Join(" ", table.OrderBy(e => e)));
    }
}