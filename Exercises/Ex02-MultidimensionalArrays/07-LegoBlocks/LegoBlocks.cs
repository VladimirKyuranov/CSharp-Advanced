using System;
using System.Collections.Generic;
using System.Linq;

class LegoBlocks
{
    static void Main(string[] args)
    {
        int rowsCount = int.Parse(Console.ReadLine());

        int[][] firstBlock = new int[rowsCount][];
        int[][] secondBlock = new int[rowsCount][];

        for (int row = 0; row < 2 * rowsCount; row++)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            if (row < rowsCount)
            {
                firstBlock[row] = numbers;
            }
            else
            {
                secondBlock[row - rowsCount] = numbers;
            }
        }

        int colsCount = firstBlock[0].Length + secondBlock[0].Length;

        for (int row = 0; row < rowsCount; row++)
        {
            if (firstBlock[row].Length + secondBlock[row].Length != colsCount)
            {
                int cellsCount = GetCellsCount(firstBlock, secondBlock);
                Console.WriteLine($"The total number of cells is: {cellsCount}");
                Environment.Exit(0);
            }
        }

        int[,] matrix = new int[rowsCount, colsCount];

        for (int row = 0; row < rowsCount; row++)
        {
            for (int col = 0; col < firstBlock[row].Length; col++)
            {
                matrix[row, col] = firstBlock[row][col];
            }

            int currentCol = firstBlock[row].Length;

            for (int col = secondBlock[row].Length - 1; col >= 0; col--)
            {
                matrix[row, currentCol++] = secondBlock[row][col];
            }
        }

        PrintMatrix(matrix);
    }

    private static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            List<int> tempList = new List<int>();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                tempList.Add(matrix[row, col]);
            }

            Console.WriteLine($"[{string.Join(", ", tempList)}]");
        }
    }

    private static int GetCellsCount(int[][] firstBlock, int[][] secondBlock)
    {
        int count = 0;

        for (int row = 0; row < firstBlock.Length; row++)
        {
            count += firstBlock[row].Length;
        }

        for (int row = 0; row < secondBlock.Length; row++)
        {
            count += secondBlock[row].Length;
        }

        return count;
    }
}