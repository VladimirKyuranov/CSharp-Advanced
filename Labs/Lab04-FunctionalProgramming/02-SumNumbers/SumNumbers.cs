using System;
using System.Collections.Generic;
using System.Linq;

class SumNumbers
{
    static void Main(string[] args)
    {
        List<int> numbers = Console.ReadLine()
            .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        Console.WriteLine(numbers.Count);
        Console.WriteLine(numbers.Sum());
    }
}