using System;
using System.Linq;
using System.Text.RegularExpressions;

class DataTransfer
{
    static void Main(string[] args)
    {
        int linesCount = int.Parse(Console.ReadLine());
        string pattern = @"^s:(?<sender>[^;]+);r:(?<receiver>[^;]+);m--(?<message>""[a-zA-Z ]+"")$";
        int totalDataSize = 0;

        for (int counter = 0; counter < linesCount; counter++)
        {
            string data = Console.ReadLine();
            Match match = Regex.Match(data, pattern);


            if (!match.Success)
            {
                continue;
            }

            string sender = match.Groups["sender"].Value;
            string receiver = match.Groups["receiver"].Value;
            string message = match.Groups["message"].Value;

            foreach (var digit in (sender + receiver)
                .Where(d => Char.IsDigit(d)))
            {
                totalDataSize += int.Parse(digit.ToString());
            }

            sender = string.Join("", sender.Where(c => Char.IsLetter(c) || Char.IsWhiteSpace(c)));
            receiver = string.Join("", receiver.Where(c => Char.IsLetter(c) || Char.IsWhiteSpace(c)));

            Console.WriteLine($"{sender} says {message} to {receiver}");
        }

        Console.WriteLine($"Total data transferred: {totalDataSize}MB");
    }
}