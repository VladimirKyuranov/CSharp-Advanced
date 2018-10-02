using System;
using System.Collections.Generic;

class UniqueUsernames
{
    static void Main(string[] args)
    {
        int usernamesCount = int.Parse(Console.ReadLine());
        HashSet<string> usernames = new HashSet<string>();

        for (int counter = 0; counter < usernamesCount; counter++)
        {
            string username = Console.ReadLine();
            usernames.Add(username);
        }

        Console.WriteLine(string.Join(Environment.NewLine, usernames));
    }
}