using System;
using System.Collections.Generic;
using System.Linq;

class CupsAndBottles
{
    static void Main(string[] args)
    {
        Queue<int> cups = new Queue<int>(
            Console.ReadLine()
            .Split()
            .Select(int.Parse));
        Stack<int> bottles = new Stack<int>(
            Console.ReadLine()
            .Split()
            .Select(int.Parse));
        int wastedWater = 0;

        while (cups.Count > 0 && bottles.Count > 0)
        {
            int cup = cups.Dequeue();
            int bottle = bottles.Pop();

            while (true)
            {
                int difference = bottle - cup;

                if (difference >= 0)
                {
                    wastedWater += difference;
                    break;
                }

                cup -= bottle;

                if (bottles.Count > 0)
                {
                    bottle = bottles.Pop();
                }
            }
        }

        if (cups.Count > 0)
        {
            Console.WriteLine($"Cups: {string.Join(" ", cups)}");
        }
        else
        {
            Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
        }

        Console.WriteLine($"Wasted litters of water: {wastedWater}");
    }
}