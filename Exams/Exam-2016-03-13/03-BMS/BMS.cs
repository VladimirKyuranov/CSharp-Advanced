using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class BMS
{
    static void Main(string[] args)
    {
        int row = 1;
        string input;
        StringBuilder builder = new StringBuilder();
        string pattern = @"\s*<\s*(?<command>[a-z]+)\s+(?:value\s*=\s*""\s*(?<count>\d+)\s*""\s+)?[a-z]+\s*=\s*""(?<content>[^""]*)""\s*\/>\s*";

        while ((input = Console.ReadLine()) != "<stop/>")
        {
            Match match = Regex.Match(input, pattern);

            if (match == null)
            {
                continue;
            }

            string command = match.Groups["command"].Value;
            string text = match.Groups["content"].Value;

            if (text.Length == 0)
            {
                continue;
            }

            switch (command)
            {
                case "inverse":
                    text = string.Join("", text
                        .ToCharArray()
                        .Select(c =>
                        {
                            return char.IsLower(c) ? char.ToUpper(c) : char.ToLower(c);
                        }));
                    builder.AppendLine($"{row++}. {text}");
                    break;
                case "reverse":
                    text = string.Join("", text
                        .ToCharArray()
                        .Reverse());
                    builder.AppendLine($"{row++}. {text}");
                    break;
                case "repeat":
                    int count = int.Parse(match.Groups["count"].Value);
                    for (int counter = 0; counter < count; counter++)
                    {
                        builder.AppendLine($"{row++}. {text}");
                    }
                    break;
                default:
                    break;
            }
        }

        Console.WriteLine(builder.ToString().Trim());
    }
}