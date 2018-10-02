using System;
using System.Collections.Generic;

class ParkingLot
{
    static void Main(string[] args)
    {
        HashSet<string> parking = new HashSet<string>();
        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            string[] carArgs = input
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string direction = carArgs[0];
            string carNumber = carArgs[1];

            switch (direction)
            {
                case "IN":
                    parking.Add(carNumber);
                    break;
                case "OUT":
                    parking.Remove(carNumber);
                    break;
                default:
                    Console.WriteLine("Invalid Direction");
                    break;
            }
        }

        if (parking.Count == 0)
        {
            Console.WriteLine("Parking Lot is Empty");
            Environment.Exit(0);
        }

        foreach (string carNumber in parking)
        {
            Console.WriteLine(carNumber);
        }
    }
}