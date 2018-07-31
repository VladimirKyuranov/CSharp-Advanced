using System;
using System.Linq;

class MatrixOfPalindromes
{
    static void Main(string[] args)
    {
        int[] size = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        char[] alphabeth = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        int rows = size[0];
        int cols = size[1];
        string[,] matrix = new string[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                char borderChars = alphabeth[row];
                char middleChar = alphabeth[row + col];

                matrix[row, col] = string.Format("{0}{1}{0}", borderChars, middleChar);
            }
        }

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write($"{matrix[row, col]} ");
            }

            Console.WriteLine();
        }
    }
}