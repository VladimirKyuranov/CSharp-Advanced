using System;
using System.Collections.Generic;
using System.Linq;

class BasicQueueOperations
{
    static void Main(string[] args)
    {
        int[] command = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
        int[] elements = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int popCount = command[1];
        int wantedElement = command[2];
        Queue<int> queue = new Queue<int>(elements);

        for (int counter = 0; counter < popCount; counter++)
        {
            if (queue.Count > 0)
            {
                queue.Dequeue();
            }
        }

        if (queue.Count < 1)
        {
            Console.WriteLine(0);
            return;
        }

        if (queue.Contains(wantedElement))
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine(queue.Min());
        }
    }
}