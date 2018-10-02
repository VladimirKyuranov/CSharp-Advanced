using System;
using System.Collections.Generic;
using System.Linq;

class CitiesByContinetAndCountry
{
    static void Main(string[] args)
    {
        Dictionary<string, Dictionary<string, List<string>>> continents =
            new Dictionary<string, Dictionary<string, List<string>>>();

        int countriesCount = int.Parse(Console.ReadLine());

        for (int counter = 0; counter < countriesCount; counter++)
        {
            string[] countryArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string continent = countryArgs[0];
            string country = countryArgs[1];
            string city = countryArgs[2];

            if (continents.ContainsKey(continent) == false)
            {
                continents.Add(continent, new Dictionary<string, List<string>>());
            }

            if (continents[continent].ContainsKey(country) == false)
            {
                continents[continent].Add(country, new List<string>());
            }

            continents[continent][country].Add(city);
        }

        foreach (var continent in continents)
        {
            Console.WriteLine($"{continent.Key}:");

            foreach (var country in continent.Value)
            {
                Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
            }
        }
    }
}