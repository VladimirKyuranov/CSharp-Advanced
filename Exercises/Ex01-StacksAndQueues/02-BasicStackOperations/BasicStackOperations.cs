using System;
using System.Collections.Generic;
using System.Linq;

class BasicStackOperations
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
        Stack<int> stack = new Stack<int>(elements);


        for (int counter = 0; counter < popCount; counter++)
        {
            if (stack.Count > 0)
            {
                stack.Pop();
            }
        }

        if (stack.Count < 1)
        {
            Console.WriteLine(0);
            return;
        }

        if (stack.Contains(wantedElement))
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine(stack.Min());
        }
    }
}