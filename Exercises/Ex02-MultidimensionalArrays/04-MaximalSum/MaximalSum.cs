using System;
using System.Linq;

class MaximalSum
{
    static void Main(string[] args)
    {
        int[] size = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int rows = size[0];
        int cols = size[1];
        int[,] matrix = new int[rows, cols];
        int maxSum = int.MinValue;
        int rowIndex = 0;
        int colIndex = 0;

        for (int row = 0; row < rows; row++)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = numbers[col];
            }
        }

        for (int row = 0; row < rows - 2; row++)
        {
            for (int col = 0; col < cols - 2; col++)
            {
                int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                    matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                    matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                if (sum > maxSum)
                {
                    maxSum = sum;
                    rowIndex = row;
                    colIndex = col;
                }
            }
        }

        Console.WriteLine($"Sum = {maxSum}");
        Console.WriteLine($"{matrix[rowIndex, colIndex]} {matrix[rowIndex, colIndex + 1]} {matrix[rowIndex, colIndex + 2]}");
        Console.WriteLine($"{matrix[rowIndex + 1, colIndex]} {matrix[rowIndex + 1, colIndex + 1]} {matrix[rowIndex + 1, colIndex + 2]}");
        Console.WriteLine($"{matrix[rowIndex + 2, colIndex]} {matrix[rowIndex + 2, colIndex + 1]} {matrix[rowIndex + 2, colIndex + 2]}");
    }
}