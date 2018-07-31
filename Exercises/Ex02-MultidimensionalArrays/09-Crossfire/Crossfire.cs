using System;
using System.Collections.Generic;
using System.Linq;

class Crossfire
{
    static void Main(string[] args)
    {
        int[] size = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int rows = size[0];
        int cols = size[1];
        long number = 1;
        List<List<long>> matrix = new List<List<long>>();
        string input = String.Empty;

        for (int row = 0; row < rows; row++)
        {
            List<long> currentRow = new List<long>();

            for (int col = 0; col < cols; col++)
            {
                currentRow.Add(number++);
            }

            matrix.Add(currentRow);
        }

        while ((input = Console.ReadLine()) != "Nuke it from orbit")
        {
            int[] bomb = input
                .Split()
                .Select(int.Parse)
                .ToArray();

            int bombRow = bomb[0];
            int bombCol = bomb[1];
            int radius = bomb[2];

            for (int row = 0; row < matrix.Count; row++)
            {
                for (int col = 0; col < matrix[row].Count; col++)
                {
                    if (row == bombRow && Math.Abs(bombCol - col) <= radius ||
                        col == bombCol && Math.Abs(bombRow - row) <= radius)
                    {
                        matrix[row][col] = 0;
                    }
                }
            }

            for (int row = 0; row < matrix.Count; row++)
            {
                matrix[row].RemoveAll(x => x == 0);
            }

            List<int> emptyRows = new List<int>();

            for (int row = 0; row < matrix.Count; row++)
            {
                if (matrix[row].Count == 0)
                {
                    emptyRows.Add(row);
                }
            }

            for (int row = emptyRows.Count - 1; row >= 0; row--)
            {
                matrix.RemoveAt(emptyRows[row]);
            }
        }

        foreach (var row in matrix)
        {
                Console.WriteLine(string.Join(" ", row));
        }
    }
}