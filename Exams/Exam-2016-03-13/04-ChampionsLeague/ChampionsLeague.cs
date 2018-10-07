using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ChampionsLeague
{
    static void Main(string[] args)
    {
        Dictionary<string, Team> teams = new Dictionary<string, Team>();
        string input;

        while ((input = Console.ReadLine()) != "stop")
        {
            string[] gameArgs = input
                .Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string firstTeamName = gameArgs[0];
            string secondTeamName = gameArgs[1];
            Team firstTeam;
            Team secondTeam;

            if (teams.ContainsKey(firstTeamName))
            {
                firstTeam = teams[firstTeamName];
            }
            else
            {
                firstTeam = new Team(firstTeamName);
                teams.Add(firstTeamName, firstTeam);
            }

            if (teams.ContainsKey(secondTeamName))
            {
                secondTeam = teams[secondTeamName];
            }
            else
            {
                secondTeam = new Team(secondTeamName);
                teams.Add(secondTeamName, secondTeam);
            }

            firstTeam.AddOpponent(secondTeamName);
            secondTeam.AddOpponent(firstTeamName);

            int[] firstResult = gameArgs[2]
                .Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] secondResult = gameArgs[3]
                .Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstTeamHomeGoals = firstResult[0];
            int firstTeamAwayGoals = secondResult[1];
            int firstTeamTotalGoals = firstTeamHomeGoals + firstTeamAwayGoals;
            int secondTeamHomeGoals = secondResult[0];
            int secondTeamAwayGoals = firstResult[1];
            int secondTeamTotalGoals = secondTeamHomeGoals + secondTeamAwayGoals;

            if (firstTeamTotalGoals > secondTeamTotalGoals)
            {
                firstTeam.Win();
            }
            else if (firstTeamTotalGoals < secondTeamTotalGoals)
            {
                secondTeam.Win();
            }
            else
            {
                if (firstTeamAwayGoals > secondTeamAwayGoals)
                {
                    firstTeam.Win();
                }
                else
                {
                    secondTeam.Win();
                }
            }
        }

        foreach (var team in teams
            .OrderByDescending(t => t.Value.Wins)
            .ThenBy(t => t.Key))
        {
            Console.WriteLine(team.Value);
        }
    }
}

class Team
{
    public Team(string name)
    {
        this.Name = name;
        this.Opponents = new List<string>();
    }

    public string Name { get; private set; }

    public int Wins { get; private set; }

    public List<string> Opponents { get; private set; }

    public void Win()
    {
        this.Wins++;
    }

    public void AddOpponent(string opponent)
    {
        this.Opponents.Add(opponent);
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine(this.Name);
        builder.AppendLine($"- Wins: {this.Wins}");
        builder.AppendLine($"- Opponents: {string.Join(", ", this.Opponents.OrderBy(o => o))}");
        return builder.ToString().TrimEnd();
    }
}