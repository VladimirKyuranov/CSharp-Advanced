using System;
using System.Collections.Generic;

class EvenTimes
{
    static void Main(string[] args)
    {
        Dictionary<int, int> numbers = new Dictionary<int, int>();
        int count = int.Parse(Console.ReadLine());

        for (int counter = 0; counter < count; counter++)
        {
            int number = int.Parse(Console.ReadLine());

            if (numbers.ContainsKey(number) == false)
            {
                numbers.Add(number, 0);
            }

            numbers[number]++;
        }

        foreach (var number in numbers)
        {
            if (number.Value % 2 == 0)
            {
                Console.WriteLine(number.Key);
                break;
            }
        }
    }
}