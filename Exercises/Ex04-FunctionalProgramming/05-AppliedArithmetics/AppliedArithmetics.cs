using System;
using System.Linq;

class AppliedArithmetics
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine()
            .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        string command;

        while ((command = Console.ReadLine()) != "end")
        {

            if (command == "print")
            {
                var print = Print();
                print(numbers);
            }
            else
            {
                numbers = numbers.Select(ApplyCommand(command)).ToArray();
            }
        }
    }

    static Func<int, int> ApplyCommand(string command)
    {
        switch (command)
        {
            case "add":
                return x => x + 1;
            case "subtract":
                return x => x - 1;
            case "multiply":
                return x => x * 2;
            default:
                throw new Exception();
        }
    }

    static Action<int[]> Print()
    {
        return x => Console.WriteLine(string.Join(" ", x));
    }
}