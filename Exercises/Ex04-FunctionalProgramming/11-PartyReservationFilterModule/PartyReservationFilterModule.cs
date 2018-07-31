using System;
using System.Collections.Generic;
using System.Linq;

class PartyReservationFilterModule
{
    static void Main(string[] args)
    {
        List<string> invitations = Console.ReadLine()
            .Split()
            .ToList();

        var filters = new List<Filter>();
        string input;

        while ((input = Console.ReadLine()) != "Print")
        {
            string[] filterArgs = input
                .Split(';')
                .ToArray();

            string filterType = filterArgs[0];
            Filter filter = new Filter
            {
                Condition = filterArgs[1],
                Parameter = filterArgs[2]
            };

            switch (filterType)
            {
                case "Add filter":
                    filters.Add(filter);
                    break;
                case "Remove filter":
                    filters.RemoveAll(f => f.Condition == filter.Condition && f.Parameter == filter.Parameter);
                    break;
            }
        }


        foreach (Filter filter in filters)
        {
            string condition = filter.Condition;
            string parameter = filter.Parameter;
            var applyFilter = ApplyFilter(condition, parameter);
            var toBeRemoved = new List<string>();
            toBeRemoved.AddRange(invitations.Where(applyFilter));

            foreach (var guest in toBeRemoved)
            {
                invitations.Remove(guest);
            }
        }

        Console.WriteLine(string.Join(" ", invitations));
    }

    static Func<string, bool> ApplyFilter(string condition, string parameter)
    {
        switch (condition)
        {
            case "Starts with":
                return x => x.StartsWith(parameter);
            case "Ends with":
                return x => x.EndsWith(parameter);
            case "Contains":
                return x => x.Contains(parameter);
            case "Length":
                return x => x.Length == int.Parse(parameter);
            default:
                throw new NotImplementedException();
        }
    }
}

class Filter
{
    public string Condition { get; set; }
    public string Parameter { get; set; }
}