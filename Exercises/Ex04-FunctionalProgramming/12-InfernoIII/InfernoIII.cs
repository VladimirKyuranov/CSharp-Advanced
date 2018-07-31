using System;
using System.Collections.Generic;
using System.Linq;

class InfernoIII
{
    static void Main(string[] args)
    {
        List<int> numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        List<Filter> filters = new List<Filter>();
        string input;

        while ((input = Console.ReadLine()) != "Forge")
        {
            string[] commandArgs = input
                .Split(';');

            string command = commandArgs[0];
            string type = commandArgs[1];
            int parameter = int.Parse(commandArgs[2]);

            Filter filter = new Filter
            {
                Type = type,
                Parameter = parameter
            };

            switch (command)
            {
                case "Exclude":
                    filters.Add(filter);
                    break;
                case "Reverse":
                    filters.RemoveAll(f => f.Type == type && f.Parameter == parameter);
                    break;
            }
        }

        List<int> indexes = new List<int>();

        foreach (Filter filter in filters)
        {
            var applyFilter = ApplyFilter(filter, numbers);

            for (int i = 0; i < numbers.Count; i++)
            {
                if (applyFilter(i))
                {
                    indexes.Add(i);
                }
            }
        }

        Console.WriteLine(string.Join(" ", numbers.Where(n => !indexes.Contains(numbers.IndexOf(n)))));
    }

    static Func<int, bool> ApplyFilter(Filter filter, List<int> numbers)
    {
        switch (filter.Type)
        {
            case "Sum Left":
                return x =>
                {
                    int leftNumber = x > 0 ? numbers[x - 1] : 0;
                    int number = numbers[x];
                    int sum = leftNumber + numbers[x];
                    return sum == filter.Parameter;
                };
            case "Sum Right":
                return x =>
                {
                    int rigthNumber = x < numbers.Count - 1 ? numbers[x + 1] : numbers[numbers.Count - 1];
                    int sum = numbers[rigthNumber] + numbers[x];
                    return sum == filter.Parameter;
                };
            case "Sum Left Right":
                return x =>
                {
                    int leftNumber = x > 0 ? numbers[x - 1] : 0;
                    int rigthNumber = x < numbers.Count - 1 ? numbers[x + 1] : 0;
                    int sum = leftNumber + rigthNumber + numbers[x];
                    return sum == filter.Parameter;
                };
            default:
                throw new NotImplementedException();
        }
    }
}

class Filter
{
    public string Type { get; set; }
    public int Parameter { get; set; }
}