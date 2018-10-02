using System;
using System.Collections.Generic;
using System.Linq;

class CountSymbols
{
    static void Main(string[] args)
    {
        SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

        Console.ReadLine()
            .ToCharArray()
            .ToList()
            .ForEach(ch =>
            {
                if (symbols.ContainsKey(ch) == false)
                {
                    symbols.Add(ch, 0);
                }

                symbols[ch]++;
            });

        foreach (var symbol in symbols)
        {
            Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
        }
    }
}