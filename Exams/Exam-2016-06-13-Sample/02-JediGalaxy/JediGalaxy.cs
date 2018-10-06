using System;
using System.Linq;

class JediGalaxy
{
    static void Main(string[] args)
    {
        int[] size = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
        int[,] galaxy = new int[size[0], size[1]];
        string input;
        long collectedStars = 0;

        FillGalaxy(galaxy);

        while ((input = Console.ReadLine()) != "Let the Force be with you")
        {
            int[] ivoCoords = input
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] evilCoords = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int ivoStartRow = ivoCoords[0];
            int ivoStartCol = ivoCoords[1];
            int evilStartRow = evilCoords[0];
            int evilStartCol = evilCoords[1];

            for (int row = evilStartRow; row >= 0; row--)
            {
                if (CheckRowCol(row, evilStartCol, galaxy))
                {
                    galaxy[row, evilStartCol] = 0;
                }
                evilStartCol--;
            }

            for (int row = ivoStartRow; row >= 0; row--)
            {
                if (CheckRowCol(row, ivoStartCol, galaxy))
                {
                    collectedStars += galaxy[row, ivoStartCol];
                }
                ivoStartCol++;
            }
        }

        Console.WriteLine(collectedStars);
    }

    static void FillGalaxy(int[,] galaxy)
    {
        int stars = 0;
        for (int row = 0; row < galaxy.GetLength(0); row++)
        {
            for (int col = 0; col < galaxy.GetLength(1); col++)
            {
                galaxy[row, col] = stars++;
            }
        }
    }

    static bool CheckRowCol(int row, int col, int[,] galaxy)
    {
        return 0 <= row && row < galaxy.GetLength(0)
            && 0 <= col && col < galaxy.GetLength(1);
    }
}