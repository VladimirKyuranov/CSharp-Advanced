using System;
using System.Linq;

class KnigthsOfHonor
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine()
            .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(x => $"Sir {x}")
            .ToArray();

        var print = Print();

        foreach (var text in input)
        {
            print(text);
        }
    }

    static Action<string> Print()
    {
        return s => Console.WriteLine(s);
    }
}