using System;
using System.Linq;

class SquaresInMatrix
{
    static void Main(string[] args)
    {
        int[] size = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

        int rows = size[0];
        int cols = size[1];
        char[,] matrix = new char[rows, cols];
        int squaresCount = 0;

        for (int row = 0; row < rows; row++)
        {
            char[] chars = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = chars[col];
            }
        }

        for (int row = 0; row < rows - 1; row++)
        {
            for (int col = 0; col < cols - 1; col++)
            {
                bool isEqual = matrix[row, col] == matrix[row, col + 1]
                    && matrix[row, col] == matrix[row + 1, col]
                    && matrix[row, col] == matrix[row + 1, col + 1];

                if (isEqual)
                {
                    squaresCount++;
                }
            }
        }

        Console.WriteLine(squaresCount);
    }
}