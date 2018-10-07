using System;

class SquareOfStars
{
    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());

        string firstLastRow = new string('*', size);
        string middlerow = $"*{new string(' ', size - 2)}*";

        Console.WriteLine(firstLastRow);

        for (int counter = 0; counter < size - 2; counter++)
        {
            Console.WriteLine(middlerow);
        }

        Console.WriteLine(firstLastRow);
    }
}