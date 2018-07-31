using System;
using System.Collections.Generic;

class HotPotato
{
    static void Main(string[] args)
    {
        string[] children = Console.ReadLine()
            .Split();
        int fatalToss = int.Parse(Console.ReadLine());

        Queue<string> queue = new Queue<string>(children);

        while (queue.Count > 1)
        {
            for (int toss = 1; toss < fatalToss; toss++)
            {
                queue.Enqueue(queue.Dequeue());
            }

            Console.WriteLine($"Removed {queue.Dequeue()}");
        }

        Console.WriteLine($"Last is {queue.Dequeue()}");
    }
}