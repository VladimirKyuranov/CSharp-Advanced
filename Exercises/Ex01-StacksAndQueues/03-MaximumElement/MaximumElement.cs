using System;
using System.Collections.Generic;

class MaximumElement
{
    static void Main(string[] args)
    {
        Stack<int> stack = new Stack<int>();
        Stack<int> stackMax = new Stack<int>();

        stackMax.Push(int.MinValue);

        int commandsCount = int.Parse(Console.ReadLine());

        for (int counter = 0; counter < commandsCount; counter++)
        {
            string command = Console.ReadLine();

            switch (int.Parse(command[0].ToString()))
            {
                case 1:
                    int element = int.Parse(command.Substring(2));

                    stack.Push(element);

                    if (stackMax.Peek() <= element)
                    {
                        stackMax.Push(element);
                    }

                    break;
                case 2:
                    if (stack.Pop() == stackMax.Peek())
                    {
                        stackMax.Pop();
                    }

                    break;
                case 3:
                    Console.WriteLine(stackMax.Peek());
                    break;
            }
        }
    }
}