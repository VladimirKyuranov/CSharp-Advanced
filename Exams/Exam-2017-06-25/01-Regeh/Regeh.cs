using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class Regeh
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string pattern = @"\[[^[]+<(?<firstIndex>\d+)REGEH(?<secondIndex>\d+)>[^]]+\]";

        MatchCollection matches = Regex.Matches(input, pattern);

        List<int> indexes = new List<int>();
        int indexSum = 0;
        StringBuilder result = new StringBuilder();
        
        foreach (Match match in matches)
        {
            int firstIndex = int.Parse(match.Groups["firstIndex"].Value);
            int secondIndex = int.Parse(match.Groups["secondIndex"].Value);
            indexes.Add(firstIndex + indexSum);
            indexSum += firstIndex;
            indexes.Add(secondIndex + indexSum);
            indexSum += secondIndex;
        }

        foreach (int index in indexes)
        {
            result.Append(input[index % (input.Length - 1)]);
        }

        Console.WriteLine(result);
    }
}