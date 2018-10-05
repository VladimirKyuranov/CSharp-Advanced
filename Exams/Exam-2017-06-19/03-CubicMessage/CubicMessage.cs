using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class CubicMessage
{
    static void Main(string[] args)
    {
        string input;

        while ((input = Console.ReadLine()) != "Over!")
        {
            int length = int.Parse(Console.ReadLine());
            string pattern = $@"^(?<digits>\d+)(?<message>[a-zA-Z]{{{length}}})(?<end>[^a-zA-Z]*)$";
            Match match = Regex.Match(input, pattern);

            if (match.Success == false)
            {
                continue;
            }

            string message = match.Groups["message"].Value;
            List<int> digits = match.Groups["digits"].Value
                .ToCharArray()
                .Select(d => int.Parse(d.ToString()))
                .ToList();
            List<int> end = match.Groups["end"].Value
                .ToCharArray()
                .Where(c => char.IsDigit(c))
                .Select(x => int.Parse(x.ToString()))
                .ToList();
            StringBuilder builder = new StringBuilder();
            builder.Append($"{message} == ");
            digits.AddRange(end);

            digits
                .ForEach(d =>
                {
                    if (0 <= d && d < message.Length)
                    {
                        builder.Append(message[d]);
                    }
                    else
                    {
                        builder.Append(" ");
                    }
                });

            Console.WriteLine(builder.ToString().TrimEnd());
        }
    }
}