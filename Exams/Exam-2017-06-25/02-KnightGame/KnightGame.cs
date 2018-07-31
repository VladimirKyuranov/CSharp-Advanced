using System;

class KnightGame
{
    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());

        char[][] board = new char[size][];

        for (int row = 0; row < size; row++)
        {
            board[row] = Console.ReadLine().ToCharArray();
        }

        int removedKnigths = 0;

        while (true)
        {
            int maxTargets = 0;
            int[] position = new int[2];

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (board[row][col] == 'K')
                    {
                        int targets = TargetsCount(board, row, col, size);
                        if (targets > maxTargets)
                        {
                            maxTargets = targets;
                            position = new int[] { row, col };
                        }
                    }
                }
            }

            if (maxTargets == 0)
            {
                break;
            }
            else
            {
                board[position[0]][position[1]] = '0';
                removedKnigths++;
            }
        }

        Console.WriteLine(removedKnigths);
    }

    static int TargetsCount(char[][] board, int row, int col, int size)
    {
        int targetsCount = 0;

        if (row - 2 >= 0 && col - 1 >= 0 && board[row - 2][col - 1] == 'K')
        {
            targetsCount++;
        }


        if (row - 2 >= 0 && col + 1 < size && board[row - 2][col + 1] == 'K')
        {
            targetsCount++;
        }


        if (row - 1 >= 0 && col - 2 >= 0 && board[row - 1][col - 2] == 'K')
        {
            targetsCount++;
        }


        if (row - 1 >= 0 && col + 2 < size && board[row - 1][col + 2] == 'K')
        {
            targetsCount++;
        }


        if (row + 2 < size && col + 1 < size && board[row + 2][col + 1] == 'K')
        {
            targetsCount++;
        }


        if (row + 2 < size && col - 1 >= 0 && board[row + 2][col - 1] == 'K')
        {
            targetsCount++;
        }


        if (row + 1 < size && col + 2 < size && board[row + 1][col + 2] == 'K')
        {
            targetsCount++;
        }


        if (row + 1 < size && col - 2 >= 0 && board[row + 1][col - 2] == 'K')
        {
            targetsCount++;
        }

        return targetsCount;
    }
}