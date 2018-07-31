using System;
using System.Collections.Generic;
using System.Linq;

class CountUppercaseWords
{
    static void Main(string[] args)
    {
        List<string> uppercaseWords = Console.ReadLine()
            .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Where(w => Char.IsUpper(w[0]))
            .ToList();

        Console.WriteLine(string.Join(Environment.NewLine, uppercaseWords));
    }
}