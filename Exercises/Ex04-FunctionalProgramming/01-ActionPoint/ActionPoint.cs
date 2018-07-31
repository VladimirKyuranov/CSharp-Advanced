using System;

class ActionPoint
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine()
            .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
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