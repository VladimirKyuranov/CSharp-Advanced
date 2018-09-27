using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class TicketTrouble
{
    static void Main(string[] args)
    {
        string location = Console.ReadLine();
        string suitcaseContent = Console.ReadLine();

        string patternOne = @"\[[^{}\[\]]*?{(?<location>[A-Z]{3} [A-Z]{2})}[^{}\[\]]*?{(?<seat>[A-Z])(?<row>\d{1,2})}[^{}\[\]]*?\]|{[^{}\[\]]*?\[(?<location>[A-Z]{3} [A-Z]{2})\][^{}\[\]]*?\[(?<seat>[A-Z])(?<row>\d{1,2})\][^{}\[\]]*?}";

        MatchCollection matches = Regex.Matches(suitcaseContent, patternOne);

        List<Ticket> tickets = new List<Ticket>();

        tickets = ExtractTickets(tickets, matches, location);

        Console.WriteLine($"You are traveling to {location} on seats {tickets[0].Place} and {tickets[1].Place}.");
    }

    static List<Ticket> ExtractTickets(List<Ticket> tickets, MatchCollection matches, string location)
    {
        foreach (Match match in matches)
        {
            string destination = match.Groups["location"].Value;

            if (destination == location)
            {
                string row = match.Groups["row"].Value;
                string seat = match.Groups["seat"].Value;
                Ticket ticket = new Ticket(row, seat);
                tickets.Add(ticket);
            }
        }

        if (tickets.Count > 2)
        {
            string wantedRow = string.Empty;
            bool found = false;

            for (int index = 0; index < tickets.Count - 1; index++)
            {
                for (int next = index + 1; next < tickets.Count; next++)
                {
                    if (tickets[index].Row == tickets[next].Row)
                    {
                        wantedRow = tickets[index].Row;
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    break;
                }
            }

            return tickets
                    .Where(t => t.Row == wantedRow)
                    .ToList();
        }

        return tickets;
    }

    class Ticket
    {
        private string row;
        private string seat;

        public Ticket(string row, string seat)
        {
            this.row = row;
            this.seat = seat;
        }

        public string Row => this.row;

        public string Place => $"{this.seat}{this.row}";
    }
}