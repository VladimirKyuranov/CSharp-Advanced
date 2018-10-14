using System;

class Miner
{
    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());
        char[,] field = new char[size, size];
        string[] commands = Console.ReadLine()
            .Split();
        int totalCoals = 0;
        int collectedCoals = 0;
        Position position = new Position();

        for (int row = 0; row < size; row++)
        {
            char[] content = Console.ReadLine().Replace(" ", "").ToCharArray();

            for (int col = 0; col < size; col++)
            {
                char cell = content[col];
                field[row, col] = cell;

                if (cell == 'c')
                {
                    totalCoals++;
                }

                if (cell == 's')
                {
                    position.Row = row;
                    position.Col = col;
                }
            }
        }



        foreach (string command in commands)
        {
            switch (command)
            {
                case "left":
                    if (position.Col > 0)
                    {
                        position.Col--;
                        CheckField(field, ref totalCoals, ref collectedCoals, position);
                    }
                    break;
                case "right":
                    if (position.Col < size - 1)
                    {
                        position.Col++;
                        CheckField(field, ref totalCoals, ref collectedCoals, position);
                    }
                    break;
                case "up":
                    if (position.Row > 0)
                    {
                        position.Row--;
                        CheckField(field, ref totalCoals, ref collectedCoals, position);
                    }
                    break;
                case "down":
                    if (position.Row < size - 1)
                    {
                        position.Row++;
                        CheckField(field, ref totalCoals, ref collectedCoals, position);
                    }
                    break;
                default:
                    break;
            }
        }

        Console.WriteLine($"{totalCoals} coals left. ({position.Row}, {position.Col})");
    }

    private static void CheckField(char[,] field, ref int totalCoals, ref int collectedCoals, Position position)
    {
        if (field[position.Row, position.Col] == 'c')
        {
            totalCoals--;
            collectedCoals++;
            field[position.Row, position.Col] = '*';

            if (totalCoals == 0)
            {
                Console.WriteLine($"You collected all coals! ({position.Row}, {position.Col})");
                Environment.Exit(0);
            }
        }

        if (field[position.Row, position.Col] == 'e')
        {
            Console.WriteLine($"Game over! ({position.Row}, {position.Col})");
            Environment.Exit(0);
        }
    }

    class Position
    {
        public int Row { get; set; }

        public int Col { get; set; }
    }
}