using System;
using System.Linq;

class TargetPractice
{
    static void Main(string[] args)
    {
        int[] size = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
        string snake = Console.ReadLine();
        int[] shot = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int rows = size[0];
        int cols = size[1];
        int impactRow = shot[0];
        int impactCol = shot[1];
        int radius = shot[2];
        char[,] stairs = new char[rows, cols];
        int floor = 1;
        int snakeIndex = 0;

        for (int row = rows - 1; row >= 0; row--)
        {
            if (floor % 2 != 0)
            {
                for (int col = cols - 1; col >= 0; col--)
                {
                    if (snakeIndex == snake.Length)
                    {
                        snakeIndex = 0;
                    }

                    stairs[row, col] = snake[snakeIndex++];
                }
            }
            else
            {
                for (int col = 0; col < cols; col++)
                {
                    if (snakeIndex == snake.Length)
                    {
                        snakeIndex = 0;
                    }

                    stairs[row, col] = snake[snakeIndex++];
                }
            }

            floor++;
        }

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                int a = impactRow - row;
                int b = impactCol - col;
                double distance = Math.Sqrt(a * a + b * b);

                if (distance <= radius)
                {
                    stairs[row, col] = ' ';
                }
            }
        }

        while(true)
        {
            bool moved = false;

            for (int row = rows - 1; row > 0; row--)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (stairs[row, col] == ' ' && stairs[row - 1, col] != ' ')
                    {
                        stairs[row, col] = stairs[row - 1, col];
                        stairs[row - 1, col] = ' ';
                        moved = true;
                    }
                }
            }

            if (moved == false)
            {
                break;
            }
        }

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write(stairs[row, col]);
            }

            Console.WriteLine();
        }
    }
}