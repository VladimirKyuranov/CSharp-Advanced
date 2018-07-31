using System;
using System.Linq;

class ParkingSystem
{
    static void Main(string[] args)
    {
        int[] size = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int rows = size[0];
        int cols = size[1];
        bool[][] parking = new bool[rows][];

        string car = string.Empty;

        while ((car = Console.ReadLine()) != "stop")
        {
            int[] carArgs = car
                .Split()
                .Select(int.Parse)
                .ToArray();
            int entryRow = carArgs[0];
            int desiredRow = carArgs[1];
            int desiredCol = carArgs[2];
            int distance = Math.Abs(desiredRow - entryRow) + 1;
            bool fullRow = true;

            if (parking[desiredRow] == null)
            {
                parking[desiredRow] = new bool[cols];
            }

            for (int col = 1; col < cols; col++)
            {
                if (parking[desiredRow][col] == false)
                {
                    fullRow = false;
                    break;
                }
            }

            if (fullRow)
            {
                Console.WriteLine($"Row {desiredRow} full");
                continue;
            }

            if (parking[desiredRow][desiredCol] == false)
            {
                parking[desiredRow][desiredCol] = true;
                distance += desiredCol;
                Console.WriteLine(distance);
                continue;
            }

            int closestSpotDistance = 0;
            int parkedCol = 0;
            bool spaceBefore = false;

            for (int col = desiredCol - 1; col > 0; col--)
            {
                if (parking[desiredRow][col] == false)
                {
                    closestSpotDistance = desiredCol - col;
                    parkedCol = col;
                    spaceBefore = true;
                    break;
                }
            }

            for (int col = desiredCol + 1; col < cols; col++)
            {
                if (parking[desiredRow][col] == false && (closestSpotDistance > col - desiredCol || spaceBefore == false))
                {
                    parkedCol = col;
                    break;
                }
            }

            parking[desiredRow][parkedCol] = true;
            Console.WriteLine(distance + parkedCol);
        }
    }
}