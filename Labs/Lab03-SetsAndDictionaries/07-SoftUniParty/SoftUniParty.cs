using System;
using System.Collections.Generic;

class SoftUniParty
{
    static void Main(string[] args)
    {
        string input;
        HashSet<string> vip = new HashSet<string>();
        HashSet<string> guests = new HashSet<string>();

        while ((input = Console.ReadLine()) != "PARTY")
        {
            if (Char.IsDigit(input[0]))
            {
                vip.Add(input);
            }
            else
            {
                guests.Add(input);
            }
        }

        while ((input = Console.ReadLine()) != "END")
        {
            if (Char.IsDigit(input[0]))
            {
                vip.Remove(input);
            }
            else
            {
                guests.Remove(input);
            }
        }

        Console.WriteLine(vip.Count + guests.Count);

        if (vip.Count != 0)
        {
            Console.WriteLine(string.Join(Environment.NewLine, vip));
        }

        if (guests.Count != 0)
        {
            Console.WriteLine(string.Join(Environment.NewLine, guests));
        }
    }
}