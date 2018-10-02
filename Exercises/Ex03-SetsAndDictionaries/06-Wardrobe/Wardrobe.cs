using System;
using System.Collections.Generic;
using System.Linq;

class Wardrobe
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());
        Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

        for (int counter = 0; counter < count; counter++)
        {
            string[] clothesArgs = Console.ReadLine()
                .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
            string color = clothesArgs[0];
            string[] clothes = clothesArgs[1]
                .Split(",", StringSplitOptions.RemoveEmptyEntries);

            if (wardrobe.ContainsKey(color) == false)
            {
                wardrobe.Add(color, new Dictionary<string, int>());
            }

            foreach (var cloth in clothes)
            {
                if (wardrobe[color].ContainsKey(cloth) == false)
                {
                    wardrobe[color].Add(cloth, 0);
                }

                wardrobe[color][cloth]++;
            }
        }

        string[] target = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string targetColor = target[0];
        string targetCloth = target[1];

        foreach (var color in wardrobe)
        {
            Console.WriteLine($"{color.Key} clothes:");

            foreach (var cloth in color.Value)
            {
                string result = $"* {cloth.Key} - {cloth.Value}";

                if (targetColor == color.Key && targetCloth == cloth.Key)
                {
                    result += " (found!)";
                }

                Console.WriteLine(result);
            }
        }
    }
}