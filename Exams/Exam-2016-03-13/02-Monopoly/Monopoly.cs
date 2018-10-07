using System;
using System.Linq;

class Monopoly
{
    static void Main(string[] args)
    {
        int[] size = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
        int rows = size[0];
        int cols = size[1];
        int money = 50;
        int hotels = 0;
        int turn = 0;
        char[][] board = new char[rows][];

        for (int row = 0; row < rows; row++)
        {
            board[row] = Console.ReadLine()
                .ToCharArray();
        }

        for (int row = 0; row < rows; row++)
        {
            if (row % 2 == 0)
            {
                for (int col = 0; col < cols; col++)
                {
                    Move(ref money, ref hotels, ref turn, board, row, col);
                }
            }
            else
            {
                for (int col = cols - 1; col >= 0; col--)
                {
                    Move(ref money, ref hotels, ref turn, board, row, col);
                }
            }
        }

        Console.WriteLine($"Turns {turn}");
        Console.WriteLine($"Money {money}");
    }

    private static void Move(ref int money, ref int hotels, ref int turn, char[][] board, int row, int col)
    {
        const int hotelIncome = 10;

        turn++;

        switch (board[row][col])
        {
            case 'H':
                hotels++;
                Console.WriteLine($"Bought a hotel for {money}. Total hotels: {hotels}.");
                money = 0;
                break;
            case 'J':
                Console.WriteLine($"Gone to jail at turn {turn - 1}.");
                turn += 2;
                money += 2 * hotels * hotelIncome;
                break;
            case 'S':
                int shopExpences = Math.Min((row + 1) * (col + 1), money);
                money -= shopExpences;
                Console.WriteLine($"Spent {shopExpences} money at the shop.");
                break;
            default:
                break;
        }

        money += hotels * hotelIncome;
    }
}