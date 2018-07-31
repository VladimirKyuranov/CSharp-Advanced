using System;
using System.Linq;

class DangerousFloor
{
    static void Main(string[] args)
    {
        char[][] board = new char[8][];

        for (int row = 0; row < 8; row++)
        {
            board[row] = Console.ReadLine()
                .Split(',')
                .Select(char.Parse)
                .ToArray();
        }

        string command;

        while ((command = Console.ReadLine()) != "END")
        {
            char piece = command[0];
            int startRow = int.Parse(command[1].ToString());
            int startCol = int.Parse(command[2].ToString());
            int destinationRow = int.Parse(command[4].ToString());
            int destinationCol = int.Parse(command[5].ToString());
            bool outOfBoard = destinationRow < 0 || destinationRow > 7
                || destinationCol < 0 || destinationCol > 7;

            if (board[startRow][startCol] != piece)
            {
                Console.WriteLine("There is no such a piece!");
                continue;
            }

            if (outOfBoard)
            {
                Console.WriteLine("Move go out of board!");
                continue;

            }

            if (ValidMove(board, piece, startRow, startCol, destinationRow, destinationCol) == false)
            {
                Console.WriteLine("Invalid move!");
                continue;
            }


            board[startRow][startCol] = 'x';
            board[destinationRow][destinationCol] = piece;
        }
    }

    private static bool ValidMove(char[][] board, char piece, int startRow, int startCol, int destinationRow, int destinationCol)
    {
        switch (piece)
        {
            case 'K':
                return KingMoveCheck(board, startRow, startCol, destinationRow, destinationCol);
            case 'R':
                return RookMoveCheck(board, startRow, startCol, destinationRow, destinationCol);
            case 'B':
                return BishopMoveCheck(board, startRow, startCol, destinationRow, destinationCol);
            case 'Q':
                return QueenMoveCheck(board, startRow, startCol, destinationRow, destinationCol);
            case 'P':
                return PawnMoveCheck(board, startRow, startCol, destinationRow, destinationCol);
            default:
                return false;
        }
    }

    private static bool PawnMoveCheck(char[][] board, int startRow, int startCol, int destinationRow, int destinationCol)
    {
        if (startCol == destinationCol && startRow == destinationRow + 1)
        {
            return true;
        }

        return false;
    }

    private static bool QueenMoveCheck(char[][] board, int startRow, int startCol, int destinationRow, int destinationCol)
    {
        return RookMoveCheck(board, startRow, startCol, destinationRow, destinationCol)
         || BishopMoveCheck(board, startRow, startCol, destinationRow, destinationCol);
    }

    private static bool BishopMoveCheck(char[][] board, int startRow, int startCol, int destinationRow, int destinationCol)
    {
        return Math.Abs(startRow - destinationRow) == Math.Abs(startCol - destinationCol);
    }

    private static bool KingMoveCheck(char[][] board, int startRow, int startCol, int destinationRow, int destinationCol)
    {
        if (destinationRow <= startRow + 1 && destinationRow >= startRow - 1
                            && destinationCol <= startCol + 1 && destinationCol >= startCol - 1)
        {
            return true;
        }

        return false;
    }

    private static bool RookMoveCheck(char[][] board, int startRow, int startCol, int destinationRow, int destinationCol)
    {
        return startRow == destinationRow || startCol == destinationCol;

    }
}