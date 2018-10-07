using System;
using System.Collections.Generic;
using System.Linq;

class ArrangeNumbers
{
    static void Main(string[] args)
    {
        string[] names = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eigth", "nine" };
        List<string> numbers = Console.ReadLine()
            .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            .OrderBy(n =>
            {
                string[] result = new string[n.Length];
                for (int index = 0; index < n.Length; index++)
                {
                    int digit = int.Parse(n[index].ToString());
                    result[index] = names[digit];
                }

                return string.Join("-", result);
            })
            .ToList();

        Console.WriteLine(string.Join(", ", numbers));
    }
}