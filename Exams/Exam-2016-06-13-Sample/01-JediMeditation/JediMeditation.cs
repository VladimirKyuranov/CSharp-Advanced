using System;
using System.Collections.Generic;
using System.Linq;

class JediMeditation
{
    static void Main(string[] args)
    {
        Queue<string> initialOrder = new Queue<string>();
        Queue<string> correctOrder = new Queue<string>();
        bool yodaPresent = false;
        int count = int.Parse(Console.ReadLine());

        for (int counter = 0; counter < count; counter++)
        {
            Console.ReadLine()
                .Split()
                .ToList()
                .ForEach(j =>
                {
                    if (j.StartsWith("y"))
                    {
                        yodaPresent = true;
                    }
                    else
                    {
                        initialOrder.Enqueue(j);
                    }
                });
        }

        if (yodaPresent)
        {
            Order(initialOrder, correctOrder, 'm', 'm');
            Order(initialOrder, correctOrder, 'k', 'k');
            Order(initialOrder, correctOrder, 's', 't');
        }
        else
        {
            Order(initialOrder, correctOrder, 's', 't');
            Order(initialOrder, correctOrder, 'm', 'm');
            Order(initialOrder, correctOrder, 'k', 'k');
        }

        Order(initialOrder, correctOrder, 'p', 'p');

        Console.WriteLine(string.Join(" ", correctOrder));
    }

    private static void Order(Queue<string> initialOrder, Queue<string> correctOrder, char rank, char secondRank)
    {
        for (int index = 0; index < initialOrder.Count; index++)
        {
            string current = initialOrder.Dequeue();

            if (current[0] == rank || current[0] == secondRank)
            {
                correctOrder.Enqueue(current);
                index--;
            }
            else
            {
                initialOrder.Enqueue(current);
            }
        }
    }
}