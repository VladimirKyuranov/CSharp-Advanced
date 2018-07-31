using System;
using System.Linq;

class DiagonalDifference
{
    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());

        int[,] matrix = new int[size, size];
        int primaryDiagonal = 0;
        int secondaryDiagonal = 0;

        for (int row = 0; row < size; row++)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int col = 0; col < size; col++)
            {
                matrix[row, col] = numbers[col];
            }
        }

        for (int index = 0; index < size; index++)
        {
            primaryDiagonal += matrix[index, index];
            secondaryDiagonal += matrix[size - index - 1, index];
        }

        int difference = Math.Abs(primaryDiagonal - secondaryDiagonal);

        Console.WriteLine(difference);
    }
}