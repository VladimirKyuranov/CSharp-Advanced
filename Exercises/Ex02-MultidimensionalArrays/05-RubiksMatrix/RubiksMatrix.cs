using System;
using System.Linq;

class RubiksMatrix
{
    static void Main(string[] args)
    {
        int[] size = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
        int commandsCount = int.Parse(Console.ReadLine());

        int rows = size[0];
        int cols = size[1];
        int[,] matrix = new int[rows, cols];

        FillMatrix(matrix);

        for (int currentCommand = 0; currentCommand < commandsCount; currentCommand++)
        {
            string[] commandInfo = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            int row = int.Parse(commandInfo[0]);
            int col = int.Parse(commandInfo[0]);
            string command = commandInfo[1];
            int count = int.Parse(commandInfo[2]);

            switch (command)
            {
                case "up":
                    MoveUp(rows, matrix, col, count);
                    break;
                case "down":
                    MoveDown(rows, matrix, col, count);
                    break;
                case "left":
                    MoveLeft(cols, matrix, row, count);
                    break;
                case "right":
                    MoveRight(cols, matrix, row, count);
                    break;
            }
        }

        RearangeMatrix(rows, cols, matrix);
    }

    private static void FillMatrix(int[,] matrix)
    {
        int number = 1;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = number++;
            }
        }
    }

    private static void MoveUp(int rows, int[,] matrix, int col, int count)
    {
        for (int counter = 0; counter < count % rows; counter++)
        {
            int temp = matrix[0, col];

            for (int index = 0; index < rows - 1; index++)
            {
                matrix[index, col] = matrix[index + 1, col];
            }

            matrix[rows - 1, col] = temp;
        }
    }
    
    private static void MoveDown(int rows, int[,] matrix, int col, int count)
    {
        for (int counter = 0; counter < count % rows; counter++)
        {
            int temp = matrix[rows - 1, col];

            for (int index = rows - 1; index > 0; index--)
            {
                matrix[index, col] = matrix[index - 1, col];
            }

            matrix[0, col] = temp;
        }
    }

    private static void MoveLeft(int cols, int[,] matrix, int row, int count)
    {
        for (int counter = 0; counter < count % cols; counter++)
        {
            int temp = matrix[row, 0];

            for (int index = 0; index < cols - 1; index++)
            {
                matrix[row, index] = matrix[row, index + 1];
            }

            matrix[row, cols - 1] = temp;
        }
    }

    private static void MoveRight(int cols, int[,] matrix, int row, int count)
    {
        for (int counter = 0; counter < count % cols; counter++)
        {
            int temp = matrix[row, cols - 1];

            for (int index = cols - 1; index > 0; index--)
            {
                matrix[row, index] = matrix[row, index - 1];
            }

            matrix[row, 0] = temp;
        }
    }

    private static void RearangeMatrix(int rows, int cols, int[,] matrix)
    {
        int currentNumber = 1;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (matrix[row, col] == currentNumber)
                {
                    Console.WriteLine("No swap required");
                }
                else
                {
                    for (int wantedRow = row; wantedRow < rows; wantedRow++)
                    {
                        for (int wantedCol = 0; wantedCol < cols; wantedCol++)
                        {
                            if (matrix[wantedRow, wantedCol] == currentNumber)
                            {
                                int temp = matrix[row, col];
                                matrix[row, col] = matrix[wantedRow, wantedCol];
                                matrix[wantedRow, wantedCol] = temp;
                                Console.WriteLine($"Swap ({row}, {col}) with ({wantedRow}, {wantedCol})");
                            }
                        }
                    }
                }

                currentNumber++;
            }
        }
    }
}