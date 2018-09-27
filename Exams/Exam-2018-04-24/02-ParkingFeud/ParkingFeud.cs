using System;
using System.Linq;

class ParkingFeud
{
    static void Main(string[] args)
    {
        int[] sizes = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        int entranceNumber = int.Parse(Console.ReadLine());
        int cols = sizes[1];
        int totalDistance = 0;

        while (true)
        {
            string[] spots = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            bool parked = false;
            string theSpot = spots[entranceNumber - 1];
            int conflictEntry = 0;
            int distance = CalculateDistance(cols, entranceNumber, theSpot);

            for (int i = 0; i < spots.Length; i++)
            {
                if (i == entranceNumber - 1)
                {
                    continue;
                }

                if (spots[i] == theSpot)
                {
                    conflictEntry = i + 1;
                    break;
                }
            }

            if (conflictEntry == 0)
            {
                parked = true;
                totalDistance += distance;
            }
            else
            {
                int conflictDistance = CalculateDistance(cols, conflictEntry, theSpot);

                if (distance <= conflictDistance)
                {
                    parked = true;
                    totalDistance += distance;
                }
                else
                {
                    totalDistance += 2 * distance;
                }
            }

            if (parked)
            {
                Console.WriteLine($"Parked successfully at {theSpot}.");
                Console.WriteLine($"Total Distance Passed: {totalDistance}");
                break;
            }
        }
    }

    private static int CalculateDistance(int cols, int entryNumber, string parkCell)
    {
        int row = int.Parse(parkCell.Substring(1));
        int col = (int)Enum.Parse(typeof(Columns), parkCell.Substring(0, 1));
        int rowDifference = Math.Abs(entryNumber - row);

        if (rowDifference == 0 || entryNumber + 1 == row)
        {
            return col;
        }

        if (row > entryNumber)
        {
            if (rowDifference % 2 == 0)
            {
                return (rowDifference - 1) * (cols + 3) + cols - col + 1;
            }

            return (rowDifference - 1) * (cols + 3) + col;
        }

        if (rowDifference % 2 == 0)
        {
            return (rowDifference) * (cols + 3) + col;
        }

        return (rowDifference) * (cols + 3) + cols - col + 1;
    }

    private enum Columns
    {
        A = 1,
        B, C, D, E, F, G, H, I, J, K
    }
}