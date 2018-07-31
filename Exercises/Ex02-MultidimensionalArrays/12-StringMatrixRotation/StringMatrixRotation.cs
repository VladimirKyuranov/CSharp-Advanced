using System;
using System.Collections.Generic;
using System.Linq;

class StringMatrixRotation
{
    static void Main(string[] args)
    {
        int degrees = Console.ReadLine()
            .Split("Rotate()".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray()[0] % 360;

        string text = string.Empty;
        List<string> allTexts = new List<string>();
        int maxLength = 0;

        while ((text = Console.ReadLine()) != "END")
        {
            allTexts.Add(text);

            if (text.Length > maxLength)
            {
                maxLength = text.Length;
            }
        }

        char[,] matrix = new char[allTexts.Count, maxLength];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            string currentText = allTexts[row].PadRight(maxLength);

            for (int col = 0; col < maxLength; col++)
            {
                matrix[row, col] = currentText[col];
            }
        }

        var rotatedMatrix = matrix;

        switch (degrees)
        {
            case 90:
                rotatedMatrix = Rotate(matrix);
                break;
            case 180:
                rotatedMatrix = Rotate(Rotate(matrix));
                break;
            case 270:
                rotatedMatrix = Rotate(Rotate(Rotate(matrix)));
                break;
        }

        PrintMatrix(rotatedMatrix);
    }

    private static void PrintMatrix(char[,] rotatedMatrix)
    {
        for (int row = 0; row < rotatedMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < rotatedMatrix.GetLength(1); col++)
            {
                Console.Write(rotatedMatrix[row, col]);
            }
            Console.WriteLine();
        }
    }

    private static char[,] Rotate(char[,] matrix)
    {
        char[,] rotatedMatrix = new char[matrix.GetLength(1), matrix.GetLength(0)];

        int startRow = matrix.GetLength(0) - 1;
        int startCol = 0;

        for (int row = 0; row < rotatedMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < rotatedMatrix.GetLength(1); col++)
            {
                rotatedMatrix[row, col] = matrix[startRow, startCol];
                startRow--;
            }

            startCol++;
            startRow = matrix.GetLength(0) - 1;
        }

        return rotatedMatrix;
    }
}