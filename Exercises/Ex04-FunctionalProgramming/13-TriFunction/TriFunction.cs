using System;
using System.Linq;

class TriFunction
{
    static void Main(string[] args)
    {
        int wantedSum = int.Parse(Console.ReadLine());
        string[] names = Console.ReadLine()
            .Split();

        string name = names.FirstOrDefault(x =>
        {
            int sum = 0;

            foreach (char symbol in x)
            {
                sum += symbol;
            }

            return sum >= wantedSum;
        });

        Console.WriteLine(name);
    }
}