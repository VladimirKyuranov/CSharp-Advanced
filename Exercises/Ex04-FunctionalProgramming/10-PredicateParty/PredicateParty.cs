using System;
using System.Collections.Generic;
using System.Linq;

class PredicateParty
{
    static void Main(string[] args)
    {
        List<string> guests = Console.ReadLine()
            .Split()
            .ToList();

        string input;
        while ((input = Console.ReadLine()) != "Party!")
        {
            string[] commandArgs = input.Split();

            string command = commandArgs[0];
            string condition = commandArgs[1];
            string parameter = commandArgs[2];
            var applyFilter = ApplyFilter(condition, parameter);
            var temp = new List<string>();
            foreach (string guest in guests.Where(applyFilter))
            {
                    temp.Add(guest);
            }

            switch (command)
            {
                case "Double":
                    for (int index = 0; index < guests.Count; index++)
                    {
                        string guest = guests[index];

                        if (temp.Contains(guest))
                        {
                            guests.Insert(index + 1, guest);
                            temp.Remove(guest);
                            index++;
                        }
                    }
                    break;
                case "Remove":
                    foreach (var guest in temp)
                    {
                        guests.Remove(guest);
                    }
                    break;
            }
        }

        string result = "Nobody is going to the party!";

        if (guests.Count > 0)
        {
            result = $"{string.Join(", ", guests)} are going to the party!";
        }

        Console.WriteLine(result);
    }

    static Func<string, bool> ApplyFilter(string condition, string parameter)
    {
        switch (condition)
        {
            case "StartsWith":
                return x => x.StartsWith(parameter);
            case "EndsWith":
                return x => x.EndsWith(parameter);
            case "Length":
                return x => x.Length == int.Parse(parameter);
            default:
                throw new NotImplementedException();
        }
    }
}