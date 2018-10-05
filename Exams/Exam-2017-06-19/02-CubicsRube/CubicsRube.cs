using System;
using System.Linq;

class CubicsRube
{
    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());
        int remainingBlocks = 0;
        long sum = 0;
        long[,,] cube = new long[size, size, size];
        string input;

        while ((input = Console.ReadLine()) != "Analyze")
        {
            int[] bombArgs = input
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int x = bombArgs[0];
            int y = bombArgs[1];
            int z = bombArgs[2];
            long particle = bombArgs[3];

            if (CheckDimension(x, y, z, size) && cube[x, y, z] == 0)
            {
                cube[x, y, z] = particle;
            }
        }

        foreach (long cell in cube)
        {
            if (cell == 0)
            {
                remainingBlocks++;
            }
            else
            {
                sum += cell;
            }
        }

        Console.WriteLine(sum);
        Console.WriteLine(remainingBlocks);
    }

    static bool CheckDimension(int x, int y, int z, int size)
    {
        return 0 <= x && x < size
            && 0 <= y && y < size
            && 0 <= z && z < size; 
    }
}