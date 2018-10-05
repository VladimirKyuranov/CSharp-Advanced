using System;
using System.Collections.Generic;
using System.Linq;

class CubicArtillery //40% + 2 x Memory Limit
{
    static void Main(string[] args)
    {
        int capacity = int.Parse(Console.ReadLine());
        Queue<string> bunkers = new Queue<string>();
        Queue<int> weapons = new Queue<int>();
        string input;

        while ((input = Console.ReadLine()) != "Bunker Revision")
        {
            List<string> inputArgs = input
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            inputArgs
                .ForEach(e =>
                {
                    if (int.TryParse(e, out int weapon))
                    {
                        weapons.Enqueue(weapon);
                    }
                    else
                    {
                        bunkers.Enqueue(e);
                    }
                });
        }

        while (bunkers.Count > 0)
        {
            int freeSpace = capacity;
            string name = bunkers.Dequeue();
            Queue<int> bunker = new Queue<int>();

            while (weapons.Count > 0)
            {
                int weapon = weapons.Dequeue();

                while (true)
                {
                    if (weapon <= freeSpace)
                    {
                        bunker.Enqueue(weapon);
                        freeSpace -= weapon;
                        break;
                    }
                    else if (weapon <= capacity)
                    {
                        freeSpace += bunker.Dequeue();
                    }
                    else
                    {
                        break;
                    }
                }

                if (freeSpace == 0)
                {
                    break;
                }
            }

            if (bunkers.Count > 0)
            {
                if (bunker.Count == 0)
                {
                    Console.WriteLine($"{name} -> Empty");
                }
                else if (bunker.Sum() == capacity)
                {
                    Console.WriteLine($"{name} -> {string.Join(", ", bunker)}");
                }
            }
        }
    }
}