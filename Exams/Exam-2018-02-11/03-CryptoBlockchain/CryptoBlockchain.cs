using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class CryptoBlockchain
{
    static void Main(string[] args)
    {
        int rows = int.Parse(Console.ReadLine());
        StringBuilder builder = new StringBuilder();

        for (int row = 0; row < rows; row++)
        {
            builder.Append(Console.ReadLine());
        }

        string sample = builder.ToString();
        string pattern = @"([{][^{[\]]*?(?<digitsOne>\d{3,})[^{[\]]*[}])|([[][^{[}]*?(?<digitsTwo>\d{3,})[^{[}]*[\]])";

        var matches = Regex.Matches(sample, pattern);
        List<char> validSymbols = new List<char>();

        foreach (Match match in matches)
        {
            string digits = string.Empty;

            if (match.Value.StartsWith("{"))
            {
                digits = match.Groups["digitsOne"].Value;
            }
            else
            {
                digits = match.Groups["digitsTwo"].Value;
            }

            if (digits.Length % 3 == 0)
            {
                for (int count = 0; count < digits.Length; count += 3)
                {
                    int symbolNumber = int.Parse(digits.Substring(count, 3)) - match.Value.Length;
                    validSymbols.Add((char)symbolNumber);
                }
            }
        }

        Console.WriteLine(string.Join("", validSymbols));
    }
}