using System;
using System.Text.RegularExpressions;

class TreasureMap
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());
        string pattern = @"(!|#)[^!#]*?\b(?<street>[A-Za-z]{4})\b[^!#]*(?<!\d)(?<number>\d{3})-(?<password>\d{6}|\d{4})(?!\d)[^!#]*?(?!\1)(#|!)";

        for (int counter = 0; counter < count; counter++)
        {
            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, pattern);

            Match bestMatch = matches[matches.Count / 2];

            string street = bestMatch.Groups["street"].Value;
            string streetNumber = bestMatch.Groups["number"].Value;
            string password = bestMatch.Groups["password"].Value;

            Console.WriteLine($"Go to str. {street} {streetNumber}. Secret pass: {password}.");
        }
    }
}