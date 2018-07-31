using System;
using System.Collections.Generic;
using System.Linq;

class FilterByAge
{
    static void Main(string[] args)
    {
        int peopleCount = int.Parse(Console.ReadLine());
        List<Person> people = new List<Person>();

        for (int counter = 0; counter < peopleCount; counter++)
        {
            string[] personInfo = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            string personName = personInfo[0];
            int personAge = int.Parse(personInfo[1]);
            Person person = new Person
            {
                Name = personName,
                Age = personAge
            };

            people.Add(person);
        }

        string condition = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        string format = Console.ReadLine();

        var filter = Filter(condition, age);
        var print = Print(format);

        foreach (var person in people.Where(filter))
        {
            print(person);
        }
    }

    static Func<Person, bool> Filter(string condition, int age)
    {
        if (condition == "younger")
        {
            return x => x.Age < age;
        }
        else
        {
            return x => x.Age >= age;
        }
    }

    static Action<Person> Print(string format)
    {
        switch (format)
        {
            case "name":
                return p => Console.WriteLine(p.Name);
            case "age":
                return p => Console.WriteLine(p.Age);
            default:
                return p => Console.WriteLine($"{p.Name} - {p.Age}");
        }
    }
}

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}