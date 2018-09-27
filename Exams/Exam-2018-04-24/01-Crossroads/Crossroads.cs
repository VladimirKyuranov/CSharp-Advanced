using System;
using System.Collections.Generic;

class Crossroads
{
    static void Main(string[] args)
    {
        int green = int.Parse(Console.ReadLine());
        int orange = int.Parse(Console.ReadLine());
        Queue<string> cars = new Queue<string>();
        int carsPassed = 0;

        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            if (input != "green")
            {
                cars.Enqueue(input);
                continue;
            }

            int greenTime = green;
            int orangeTime = orange;

            while (greenTime > 0 && cars.Count > 0)
            {
                string car = cars.Dequeue();
                greenTime -= car.Length;

                if (greenTime >= 0)
                {
                    carsPassed++;
                }
                else
                {
                    int timeLeft = greenTime + orangeTime;

                    if (timeLeft >= 0)
                    {
                        carsPassed++;
                    }
                    else
                    {
                        char crashed = car[car.Length + timeLeft];
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{car} was hit at {crashed}.");
                        Environment.Exit(0);
                    }
                }
            }
        }

        Console.WriteLine("Everyone is safe.");
        Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
    }
}