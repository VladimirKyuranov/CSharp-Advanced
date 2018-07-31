using System;
using System.Linq;

class PredicateForNames
{
    static void Main(string[] args)
    {
        int length = int.Parse(Console.ReadLine());
        string[] names = Console.ReadLine()
            .Split();
        var filter = Filter(length);

        Console.WriteLine(string.Join(Environment.NewLine, names.Where(filter)));
    }

    static Func<string, bool> Filter(int length)
    {
        return x => x.Length <= length;
    }
}