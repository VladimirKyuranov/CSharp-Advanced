using System;
using System.Linq;

class SumMatrixElements
{
    static void Main(string[] args)
    {
        int[] size = Console.ReadLine()
            .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int rows = size[0];
        int cols = size[1];
        int[,] matrix = new int[rows, cols];
        int sum = 0;

        for (int row = 0; row < rows; row++)
        {
            int[] numbers = Console.ReadLine()
            .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = numbers[col];
                sum += numbers[col];
            }
        }

        Console.WriteLine(matrix.GetLength(0));
        Console.WriteLine(matrix.GetLength(1));
        Console.WriteLine(sum);
    }
}