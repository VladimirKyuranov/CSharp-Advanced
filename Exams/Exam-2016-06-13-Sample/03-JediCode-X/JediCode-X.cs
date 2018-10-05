using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());
        string code = "";
        List<string> jedi = new List<string>();
        List<string> messages = new List<string>();

        for (int counter = 0; counter < count; counter++)
        {
            code += Console.ReadLine();
        }

        string namePattern = Console.ReadLine();
        int nameLength = namePattern.Length;
        string messagePattern = Console.ReadLine();
        int messageLength = messagePattern.Length;
        namePattern += $@"(?<name>[a-zA-Z]{{{nameLength}}})(?![a-zA-Z])";
        messagePattern += $@"(?<message>[a-zA-Z\d]{{{messageLength}}})(?![a-zA-Z\d])";
        MatchCollection nameMatches = Regex.Matches(code, namePattern);
        MatchCollection messageMatches = Regex.Matches(code, messagePattern);

        foreach (Match match in nameMatches)
        {
            jedi.Add(match.Groups["name"].Value);
        }

        foreach (Match match in messageMatches)
        {
            messages.Add(match.Groups["message"].Value);
        }

        Queue<int> indexes = new Queue<int>(
            Console.ReadLine()
            .Split()
            .Select(i => int.Parse(i) - 1));

        jedi
            .ForEach(j =>
            {
                while (indexes.Count > 0)
                {
                    int index = indexes.Dequeue();

                    if (0 <= index && index < messages.Count)
                    {
                        Console.WriteLine($"{j} - {messages[index]}");
                        break;
                    }
                }
            });
    }
}