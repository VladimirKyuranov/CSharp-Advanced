using System;
using System.Collections.Generic;
using System.Linq;

class CountSameValues
{
    static void Main(string[] args)
    {
        Dictionary<double, int> numbers = new Dictionary<double, int>();

        Console.ReadLine()
            .Split()
            .Select(double.Parse)
            .ToList()
            .ForEach(n =>
            {
                if (numbers.ContainsKey(n) == false)
                {
                    numbers.Add(n, 0);
                }

                numbers[n]++;
            });

        foreach (var number in numbers)
        {
            Console.WriteLine($"{number.Key} - {number.Value} times");
        }
    }
}