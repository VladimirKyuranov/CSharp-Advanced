using System;
using System.Collections.Generic;
using System.Linq;

class TruckTour
{
    static void Main(string[] args)
    {
        int pumpsCount = int.Parse(Console.ReadLine());

        Queue<int[]> pumps = new Queue<int[]>();

        for (int counter = 0; counter < pumpsCount; counter++)
        {
            int[] pump = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            pumps.Enqueue(pump);
        }

        for (int startPump = 0; startPump < pumpsCount; startPump++)
        {
            bool bestStart = true;
            int fuel = 0;

            for (int nextPump = 0; nextPump < pumpsCount; nextPump++)
            {
                int[] pump = pumps.Dequeue();
                int pumpFuel = pump[0];
                int distance = pump[1];

                pumps.Enqueue(pump);
                fuel += pumpFuel - distance;

                if (fuel < 0)
                {
                    startPump += nextPump;
                    bestStart = false;
                    break;
                }
            }

            if (bestStart)
            {
                Console.WriteLine(startPump);
                Environment.Exit(0);
            }
        }
    }
}