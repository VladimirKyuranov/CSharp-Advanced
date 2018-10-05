using System;
using System.Collections.Generic;
using System.Linq;

class CubicAssault
{
    static void Main(string[] args)
    {
        string input;
        Dictionary<string, Dictionary<string, long>> regions = new Dictionary<string, Dictionary<string, long>>();

        while ((input = Console.ReadLine()) != "Count em all")
        {
            string[] tokens = input
                .Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
            string region = tokens[0];
            string type = tokens[1];
            int amount = int.Parse(tokens[2]);
            Dictionary<string, long> meteors = new Dictionary<string, long>();
            meteors.Add("Black", 0);
            meteors.Add("Red", 0);
            meteors.Add("Green", 0);


            if (regions.ContainsKey(region) == false)
            {
                regions.Add(region, meteors);
            }

            regions[region][type] += amount;

            if (regions[region]["Green"] >= 1000000)
            {
                regions[region]["Red"] += regions[region]["Green"] / 1000000;
                regions[region]["Green"] %= 1000000;
            }

            if (regions[region]["Red"] >= 1000000)
            {
                regions[region]["Black"] += regions[region]["Red"] / 1000000;
                regions[region]["Red"] %= 1000000;
            }
        }
               
        foreach (var region in regions
            .OrderByDescending(r => r.Value["Black"])
            .ThenBy(r => r.Key.Length)
            .ThenBy(r => r.Key))
        {
            Console.WriteLine($"{region.Key}");

            foreach (var meteor in region.Value
                .OrderByDescending(m => m.Value)
                .ThenBy(m => m.Key))
            {
                Console.WriteLine($"-> {meteor.Key} : {meteor.Value}");
            }
        }
    }
}