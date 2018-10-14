using System;
using System.Collections.Generic;
using System.Linq;

class Tagram
{
    static void Main(string[] args)
    {
        var users = new Dictionary<string, Dictionary<string, int>>();
        string input;

        while ((input = Console.ReadLine()) != "end")
        {
            string[] userArgs = input
                .Split(" -> ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            if (userArgs[0] == "ban")
            {
                string toRemove = userArgs[1];

                if (users.ContainsKey(toRemove))
                {
                    users.Remove(toRemove);
                    continue;
                }
            }

            string username = userArgs[0];
            string tag = userArgs[1];
            int likes = int.Parse(userArgs[2]);

            if (!users.ContainsKey(username))
            {
                users.Add(username, new Dictionary<string, int>());
            }

            if (!users[username].ContainsKey(tag))
            {
                users[username].Add(tag, 0);
            }

            users[username][tag] += likes;
        }

        foreach (var user in users
            .OrderByDescending(u => u.Value.Values.Sum())
            .ThenBy(u => u.Value.Count))
        {
            Console.WriteLine(user.Key);

            foreach (var userTag in user.Value)
            {
                Console.WriteLine($"- {userTag.Key}: {userTag.Value}");
            }
        }
    }
}