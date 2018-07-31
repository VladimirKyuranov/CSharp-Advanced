using System;
using System.Collections.Generic;

class CalculateSequenceWithQueue
{
    static void Main(string[] args)
    {
        long number = long.Parse(Console.ReadLine());

        Queue<long> queue = new Queue<long>();
        Queue<long> helpQueue = new Queue<long>();
        int count = 1;
        queue.Enqueue(number);
        helpQueue.Enqueue(number);
        long currentNumber = helpQueue.Dequeue();

        for (int counter = 1; counter < 50; counter++)
        {

            switch (count)
            {
                case 1:
                    queue.Enqueue(currentNumber + 1);
                    helpQueue.Enqueue(currentNumber + 1);
                    count++;
                    break;
                case 2:
                    queue.Enqueue(2 * currentNumber + 1);
                    helpQueue.Enqueue(2 * currentNumber + 1);
                    count++;
                    break;
                case 3:
                    queue.Enqueue(currentNumber + 2);
                    helpQueue.Enqueue(currentNumber + 2);
                    currentNumber = helpQueue.Dequeue();
                    count = 1;
                    break;
            }
        }

        Console.WriteLine(string.Join(" ", queue));
    }
}