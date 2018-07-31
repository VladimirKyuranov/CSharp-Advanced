using System;
using System.Collections.Generic;
using System.Linq;

class GreedyTimes
{
    static void Main(string[] args)
    {
        long bagCapacity = long.Parse(Console.ReadLine());
        string[] lootArgs = Console.ReadLine()
            .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        long goldInBag = 0;
        long gemsInBag = 0;
        long cashInBag = 0;
        var bag = new Dictionary<string, Dictionary<string, long>>();

        for (int currentLoot = 0; currentLoot < lootArgs.Length; currentLoot += 2)
        {
            string lootName = lootArgs[currentLoot];
            long lootQuantity = long.Parse(lootArgs[currentLoot + 1]);

            if (bagCapacity < lootQuantity)
            {
                continue;
            }

            if (lootName.ToLower() == "gold")
            {
                if (bag.ContainsKey("Gold") == false)
                {
                    bag.Add("Gold", new Dictionary<string, long>());
                }

                if (bag["Gold"].ContainsKey(lootName) == false)
                {
                    bag["Gold"].Add(lootName, 0);
                }

                bag["Gold"][lootName] += lootQuantity;
                goldInBag += lootQuantity;
                bagCapacity -= lootQuantity;
            }
            else if (lootName.Length == 3 && cashInBag + lootQuantity <= gemsInBag)
            {
                if (bag.ContainsKey("Cash") == false)
                {
                    bag.Add("Cash", new Dictionary<string, long>());
                }

                if (bag["Cash"].ContainsKey(lootName) == false)
                {
                    bag["Cash"].Add(lootName, 0);
                }

                bag["Cash"][lootName] += lootQuantity;
                cashInBag += lootQuantity;
                bagCapacity -= lootQuantity;
            }
            else if (lootName.ToLower().EndsWith("gem") && gemsInBag + lootQuantity <= goldInBag)
            {
                if (bag.ContainsKey("Gem") == false)
                {
                    bag.Add("Gem", new Dictionary<string, long>());
                }

                if (bag["Gem"].ContainsKey(lootName) == false)
                {
                    bag["Gem"].Add(lootName, 0);
                }

                bag["Gem"][lootName] += lootQuantity;
                gemsInBag += lootQuantity;
                bagCapacity -= lootQuantity;
            }
        }

        foreach (var lootType in bag.OrderByDescending(x => x.Value.Values.Sum()))
        {
            Console.WriteLine($"<{lootType.Key}> ${lootType.Value.Values.Sum()}");

            foreach (var loot in lootType.Value.OrderByDescending(l => l.Key).ThenBy(l => l.Value))
            {
                Console.WriteLine($"##{loot.Key} - {loot.Value}");
            }
        }
    }
}