using System;
using System.Collections.Generic;
using System.Linq;

class RadioactiveBunnies
{
    static void Main(string[] args)
    {
        int[] size = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

        int rows = size[0];
        int cols = size[1];
        int[] playerPossition = new int[2];
        char[][] field = new char[rows][];

        for (int row = 0; row < rows; row++)
        {
            field[row] = Console.ReadLine().ToCharArray();
        }

        char[] moves = Console.ReadLine().ToCharArray();

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (field[row][col] == 'P')
                {
                    playerPossition[0] = row;
                    playerPossition[1] = col;
                }
            }
        }

        foreach (char move in moves)
        {
            switch (move)
            {
                case 'U':
                    if (playerPossition[0] == 0)
                    {
                        field[playerPossition[0]][playerPossition[1]] = '.';
                        field = GrowBunnies(field);
                        PrintField(field);
                        Console.WriteLine($"won: {playerPossition[0]} {playerPossition[1]}");
                        Environment.Exit(0);
                    }
                    else
                    {
                        field[playerPossition[0]][playerPossition[1]] = '.';
                        playerPossition[0]--;
                        CheckForBunny(field, playerPossition);
                        field[playerPossition[0]][playerPossition[1]] = 'P';
                        field = GrowBunnies(field);
                        CheckForDead(field, playerPossition);
                    }
                    break;
                case 'D':
                    if (playerPossition[0] == field.Length - 1)
                    {
                        field[playerPossition[0]][playerPossition[1]] = '.';
                        field = GrowBunnies(field);
                        PrintField(field);
                        Console.WriteLine($"won: {playerPossition[0]} {playerPossition[1]}");
                        Environment.Exit(0);
                    }
                    else
                    {
                        field[playerPossition[0]][playerPossition[1]] = '.';
                        playerPossition[0]++;
                        CheckForBunny(field, playerPossition);
                        field[playerPossition[0]][playerPossition[1]] = 'P';
                        field = GrowBunnies(field);
                        CheckForDead(field, playerPossition);
                    }
                    break;
                case 'L':
                    if (playerPossition[1] == 0)
                    {
                        field[playerPossition[0]][playerPossition[1]] = '.';
                        field = GrowBunnies(field);
                        PrintField(field);
                        Console.WriteLine($"won: {playerPossition[0]} {playerPossition[1]}");
                        Environment.Exit(0);
                    }
                    else
                    {
                        field[playerPossition[0]][playerPossition[1]] = '.';
                        playerPossition[1]--;
                        CheckForBunny(field, playerPossition);
                        field[playerPossition[0]][playerPossition[1]] = 'P';
                        field = GrowBunnies(field);
                        CheckForDead(field, playerPossition);
                    }
                    break;
                case 'R':
                    if (playerPossition[1] == field[0].Length - 1)
                    {
                        field[playerPossition[0]][playerPossition[1]] = '.';
                        field = GrowBunnies(field);
                        PrintField(field);
                        Console.WriteLine($"won: {playerPossition[0]} {playerPossition[1]}");
                        Environment.Exit(0);
                    }
                    else
                    {
                        field[playerPossition[0]][playerPossition[1]] = '.';
                        playerPossition[1]++;
                        CheckForBunny(field, playerPossition);
                        field[playerPossition[0]][playerPossition[1]] = 'P';
                        field = GrowBunnies(field);
                        CheckForDead(field, playerPossition);
                    }
                    break;
            }
        }

    }

    private static void CheckForDead(char[][] field, int[] playerPossition)
    {
        if (field[playerPossition[0]][playerPossition[1]] == 'B')
        {
            PrintField(field);
            Console.WriteLine($"dead: {playerPossition[0]} {playerPossition[1]}");
            Environment.Exit(0);
        }
    }

    private static void CheckForBunny(char[][] field, int[] playerPossition)
    {
        if (field[playerPossition[0]][playerPossition[1]] == 'B')
        {
            GrowBunnies(field);
            CheckForDead(field, playerPossition);
        }
    }

    private static char[][] GrowBunnies(char[][] field)
    {
        List<int[]> newBunnies = new List<int[]>();

        for (int row = 0; row < field.Length; row++)
        {
            for (int col = 0; col < field[row].Length; col++)
            {
                if (field[row][col] == 'B')
                {
                    if (row - 1 >= 0)
                    {
                        newBunnies.Add(new int[] { row - 1, col });
                    }

                    if (row + 1 < field.Length)
                    {
                        newBunnies.Add(new int[] { row + 1, col });
                    }

                    if (col - 1 >= 0)
                    {
                        newBunnies.Add(new int[] { row, col - 1 });
                    }

                    if (col + 1 < field[row].Length)
                    {
                        newBunnies.Add(new int[] { row, col + 1 });
                    }
                }
            }
        }

        foreach (var possition in newBunnies)
        {
            field[possition[0]][possition[1]] = 'B';
        }

        return field;
    }

    private static void PrintField(char[][] field)
    {
        for (int row = 0; row < field.Length; row++)
        {
            Console.WriteLine(string.Join("", field[row]));
        }
    }
}