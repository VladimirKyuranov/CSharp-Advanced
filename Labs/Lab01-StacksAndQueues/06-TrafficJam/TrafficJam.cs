using System;
using System.Collections.Generic;

class TrafficJam
{
    static void Main(string[] args)
    {
        int carsPerGreen = int.Parse(Console.ReadLine());

        string input = string.Empty;
        Queue<string> cars = new Queue<string>();
        int totalCarsPassed = 0;

        while ((input = Console.ReadLine()) != "end")
        {
            if (input != "green")
            {
                cars.Enqueue(input);
            }
            else
            {
                int passedCars = Math.Min(carsPerGreen, cars.Count);

                for (int counter = 0; counter < passedCars; counter++)
                {
                    Console.WriteLine($"{cars.Dequeue()} passed!");
                    totalCarsPassed++;
                }
            }
        }

        Console.WriteLine($"{totalCarsPassed} cars passed the crossroads.");
    }
}