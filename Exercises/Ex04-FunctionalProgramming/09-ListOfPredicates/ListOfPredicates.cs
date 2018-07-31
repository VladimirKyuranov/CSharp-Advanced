using System;
using System.Collections.Generic;
using System.Linq;

class List
{
    static void Main(string[] args)
    {
        int endOfRange = int.Parse(Console.ReadLine());
        var dividers = Console.ReadLine().
            Split()
            .Select(int.Parse)
            .ToList();

        int start = 1;
        int count = endOfRange;

        if (endOfRange >= 1)
        {
            var numbers = Enumerable.Range(start, count).ToList();

            var filter = Filter(dividers);

            numbers = filter(numbers);
            string result = string.Join(" ", numbers);

            Console.WriteLine(result);
        }
    }

    static Func<List<int>, List<int>> Filter(List<int> dividers)
    {
        return x => x.Where(n =>
        {
            bool divisable = true;

            foreach (int number in dividers)
            {
                if (n % number != 0)
                {
                    divisable = false;
                }

            }

            return divisable;
        })
        .ToList();
    }
}