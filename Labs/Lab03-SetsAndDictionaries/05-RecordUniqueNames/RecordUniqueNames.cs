using System;
using System.Collections.Generic;

class RecordUniqueNames
{
    static void Main(string[] args)
    {
        int namesCount = int.Parse(Console.ReadLine());
        HashSet<string> names = new HashSet<string>();

        for (int counter = 0; counter < namesCount; counter++)
        {
            names.Add(Console.ReadLine());
        }

        Console.WriteLine(string.Join(Environment.NewLine, names));
    }
}