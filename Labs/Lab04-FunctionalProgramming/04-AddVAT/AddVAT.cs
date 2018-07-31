using System;
using System.Linq;

class AddVAT
{
    static void Main(string[] args)
    {
        string[] numbers = Console.ReadLine()
            .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .Select(n => $"{n * 1.2:F2}")
            .ToArray();

        Console.WriteLine(string.Join(Environment.NewLine, numbers));
    }
}