using System;

class PascalTriangle
{
    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());

        long[][] triangle = new long[size][];

        for (int row = 0; row < size; row++)
        {
            int rowLength = row + 1;
            triangle[row] = new long[rowLength];
            triangle[row][0] = 1;
            triangle[row][rowLength - 1] = 1;

            if (rowLength > 2)
            {
                for (int col = 1; col < rowLength - 1; col++)
                {
                    triangle[row][col] = triangle[row - 1][col - 1] + triangle[row - 1][col];
                }
            }
        }

        for (int row = 0; row < size; row++)
        {
            Console.WriteLine(string.Join(" ", triangle[row]));
        }
    }
}