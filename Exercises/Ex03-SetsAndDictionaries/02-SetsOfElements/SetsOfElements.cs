using System;
using System.Collections.Generic;
using System.Linq;

class SetsOfElements
{
    static void Main(string[] args)
    {
        int[] sizes = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        int nSize = sizes[0];
        int mSize = sizes[1];
        HashSet<int> nSet = new HashSet<int>();
        HashSet<int> mSet = new HashSet<int>();
        HashSet<int> resultSet = new HashSet<int>();

        for (int counter = 0; counter < nSize; counter++)
        {
            int number = int.Parse(Console.ReadLine());
            nSet.Add(number);
        }

        for (int counter = 0; counter < mSize; counter++)
        {
            int number = int.Parse(Console.ReadLine());
            mSet.Add(number);
        }

        foreach (int number in nSet)
        {
            if (mSet.Contains(number))
            {
                resultSet.Add(number);
            }
        }

        Console.WriteLine(string.Join(" ", resultSet));
    }
}