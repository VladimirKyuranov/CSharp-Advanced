using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_HitList
{
    class Program
    {
        static void Main(string[] args)
        {
            int infoIndex = int.Parse(Console.ReadLine());

            var hitList = new Dictionary<string, Dictionary<string, string>>();
            string input;

            while((input = Console.ReadLine()) != "end transmissions")
            {
                string[] personInfo = input
                    .Split("=:;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                string personName = personInfo[0];

                if (hitList.ContainsKey(personName) == false)
                {
                    hitList.Add(personName, new Dictionary<string, string>());
                }

                for (int index = 1; index < personInfo.Length; index += 2)
                {
                    string key = personInfo[index];
                    string value = personInfo[index + 1];

                    if (hitList[personName].ContainsKey(key) == false)
                    {
                        hitList[personName].Add(key, value);
                    }
                    else
                    {
                        hitList[personName][key] = value;
                    }
                }
            }

            string personToKill = Console.ReadLine().Split()[1];
            int personIndex = hitList[personToKill].Sum(ptk => ptk.Key.Length) + hitList[personToKill].Sum(ptk => ptk.Value.Length);

            Console.WriteLine($"Info on {personToKill}:" +
                $"");

            foreach (var info in hitList[personToKill].OrderBy(i => i.Key))
            {
                Console.WriteLine($"---{info.Key}: {info.Value}");
            }

            Console.WriteLine($"Info index: {personIndex}");

            if (infoIndex <= personIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {infoIndex - personIndex} more info.");
            }
        }
    }
}
