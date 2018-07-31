using System;
using System.Linq;

class GroupNumbers
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

        int[] sizes = new int[3];

        foreach (int number in numbers)
        {
            sizes[Math.Abs(number % 3)]++;
        }

        int[][] groups = new int[3][];

        for (int group = 0; group < 3; group++)
        {
            groups[group] = new int[sizes[group]];
        }

        int[] indexes = new int[3];

        foreach (int number in numbers)
        {
            int remainder = Math.Abs(number % 3);
            groups[remainder][indexes[remainder]] = number;
            indexes[remainder]++;
        }

        for (int row = 0; row < 3; row++)
        {
            Console.WriteLine(string.Join(" ", groups[row]));
        }
    }
}