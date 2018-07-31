using System;
using System.Collections.Generic;
using System.Linq;

class Sneaking
{
    static void Main(string[] args)
    {
        int roomRows = int.Parse(Console.ReadLine());
        char[][] room = new char[roomRows][];

        for (int row = 0; row < roomRows; row++)
        {
            room[row] = Console.ReadLine().ToCharArray();
        }

        char[] directions = Console.ReadLine().ToCharArray();

        Location samLocation = new Location();
        Location nikoladzeLocation = new Location();
        List<Guard> guards = new List<Guard>();

        for (int row = 0; row < room.Length; row++)
        {
            for (int col = 0; col < room[row].Length; col++)
            {
                switch (room[row][col])
                {
                    case 'N':
                        nikoladzeLocation.Row = row;
                        nikoladzeLocation.Col = col;
                        break;
                    case 'S':
                        samLocation.Row = row;
                        samLocation.Col = col;
                        break;
                    case 'b':
                        Guard guard = new Guard(row, col, "right");
                        guards.Add(guard);
                        break;
                    case 'd':
                        guard = new Guard(row, col, "left");
                        guards.Add(guard);
                        break;
                }
            }
        }

        for (int move = 0; move < directions.Length; move++)
        {
            char direction = directions[move];
            Move(guards, room, samLocation, nikoladzeLocation, direction);
        }
    }

    private static void Move(List<Guard> guards, char[][] room, Location samLocation, Location nikoladzeLocation, char direction)
    {
        GuardsMove(guards, room, samLocation);

        SamMove(guards, room, samLocation, nikoladzeLocation, direction);
    }

    private static void SamMove(List<Guard> guards, char[][] room, Location samLocation, Location nikoladzeLocation, char direction)
    {
        room[samLocation.Row][samLocation.Col] = '.';

        switch (direction)
        {
            case 'U':
                samLocation.Row--;
                break;
            case 'D':
                samLocation.Row++;
                break;
            case 'L':
                samLocation.Col--;
                break;
            case 'R':
                samLocation.Col++;
                break;
        }

        CheckForGuardKill(room, samLocation, guards);
        room[samLocation.Row][samLocation.Col] = 'S';
        CheckForNikoladze(room, samLocation, nikoladzeLocation);
    }

    private static void CheckForGuardKill(char[][] room, Location samLocation, List<Guard> guards)
    {
        guards.RemoveAll(g => g.Row == samLocation.Row && g.Col == samLocation.Col);
    }

    private static void CheckForNikoladze(char[][] room, Location samLocation, Location nikoladzeLocation)
    {
        if (samLocation.Row == nikoladzeLocation.Row)
        {
            room[nikoladzeLocation.Row][nikoladzeLocation.Col] = 'X';
            Console.WriteLine("Nikoladze killed!");
            PrintRoom(room);
        }
    }

    private static void GuardsMove(List<Guard> guards, char[][] room, Location samLocation)
    {
        foreach (var guard in guards)
        {
            switch (guard.Orientation)
            {
                case "left":
                    if (guard.Col == 0)
                    {
                        guard.Orientation = "right";
                        room[guard.Row][guard.Col] = 'b';
                    }
                    else
                    {
                        room[guard.Row][guard.Col] = '.';
                        guard.Col--;
                        room[guard.Row][guard.Col] = 'd';
                    }
                    break;
                case "right":
                    if (guard.Col == room[0].Length - 1)
                    {
                        guard.Orientation = "left";
                        room[guard.Row][guard.Col] = 'd';
                    }
                    else
                    {
                        room[guard.Row][guard.Col] = '.';
                        guard.Col++;
                        room[guard.Row][guard.Col] = 'b';
                    }
                    break;
            }
        }

        Guard enemy = guards.FirstOrDefault(g => g.Row == samLocation.Row);

        if (enemy != null)
        {
            CheckForSam(room, samLocation, enemy.Row, enemy.Col, enemy.Orientation);
        }
    }

    private static void CheckForSam(char[][] room, Location samLocation, int guardRow, int guardCol, string orientation)
    {
        if (guardRow == samLocation.Row)
        {
            switch (orientation)
            {
                case "left":
                    if (samLocation.Col < guardCol)
                    {
                        Console.WriteLine($"Sam died at {samLocation.Row}, {samLocation.Col}");
                        room[samLocation.Row][samLocation.Col] = 'X';
                        PrintRoom(room);
                    }
                    break;
                case "right":
                    if (samLocation.Col > guardCol)
                    {
                        Console.WriteLine($"Sam died at {samLocation.Row}, {samLocation.Col}");
                        room[samLocation.Row][samLocation.Col] = 'X';
                        PrintRoom(room);
                    }
                    break;
            }
        }
    }

    private static void PrintRoom(char[][] room)
    {
        for (int row = 0; row < room.Length; row++)
        {
            Console.WriteLine(string.Join("", room[row]));
        }
        Environment.Exit(0);
    }
}

class Guard
{
    public int Row { get; set; }
    public int Col { get; set; }
    public string Orientation { get; set; }

    public Guard(int row, int col, string orientation)
    {
        Row = row;
        Col = col;
        Orientation = orientation;
    }
}

class Location
{
    public int Row { get; set; }
    public int Col { get; set; }
}