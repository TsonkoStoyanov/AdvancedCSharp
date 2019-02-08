using System;
using System.Data;
using System.Linq;

namespace P05_RubikMatrix
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            int[][] rubicMatrix = new int[rows][];

            GetMatrix(rubicMatrix, cols);

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] input = Console.ReadLine().Split();

                int rowCol = int.Parse(input[0]);
                string direction = input[1];
                int moves = int.Parse(input[2]);

                switch (direction)
                {
                    case "up":
                        MoveUp(rubicMatrix, rowCol, moves % rows);
                        break;
                    case "down":
                        MoveDown(rubicMatrix, rowCol, moves % rows);
                        break;
                    case "left":
                        MoveLeft(rubicMatrix, rowCol, moves % cols);
                        break;
                    case "right":
                        MoveRight(rubicMatrix, rowCol, moves % cols);
                        break;

                }
            }

            int counter = 1;

            for (int row = 0; row < rubicMatrix.Length; row++)
            {
                for (int col = 0; col < rubicMatrix[row].Length; col++)
                {
                    bool isInPlace = rubicMatrix[row][col] == counter;

                    if (isInPlace)
                    {
                        Console.WriteLine($"No swap required");
                        counter++;
                    }
                    else
                    {
                        Rearrange(rubicMatrix, counter, row, col);
                        counter++;

                    }
                }
            }

        }

        private static void Rearrange(int[][] rubicMatrix, int counter, int currentRow, int currentCol)
        {
            for (int row = 0; row < rubicMatrix.Length; row++)
            {
                for (int col = 0; col < rubicMatrix[row].Length; col++)
                {
                    if (rubicMatrix[row][col] == counter)
                    {
                        int temp = rubicMatrix[currentRow][currentCol];
                        rubicMatrix[currentRow][currentCol] = rubicMatrix[row][col];
                        rubicMatrix[row][col] = temp;

                        Console.WriteLine($"Swap ({currentRow}, {currentCol}) with ({row}, {col})");
                    }
                }
            }
        }

        private static void MoveLeft(int[][] rubicMatrix, int row, int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                int temp = rubicMatrix[row][0];

                for (int col = 0; col < rubicMatrix[row].Length - 1; col++)
                {
                    rubicMatrix[row][col] = rubicMatrix[row][col + 1];
                }

                rubicMatrix[row][rubicMatrix[row].Length - 1] = temp;
            }
        }

        private static void MoveRight(int[][] rubicMatrix, int row, int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                int temp = rubicMatrix[row][rubicMatrix[row].Length - 1];

                for (int col = rubicMatrix[row].Length - 1; col > 0; col--)
                {
                    rubicMatrix[row][col] = rubicMatrix[row] [col - 1];
                }

                rubicMatrix[row][0] = temp;
            }
        }

        private static void MoveDown(int[][] rubicMatrix, int col, int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                int temp = rubicMatrix[rubicMatrix.Length- 1][col];

                for (int row = rubicMatrix.Length - 1; row > 0; row--)
                {
                    rubicMatrix[row][col] = rubicMatrix[row - 1][col];
                }

                rubicMatrix[0][col] = temp;
            }
        }

        private static void MoveUp(int[][] rubicMatrix, int col, int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                int temp = rubicMatrix[0][col];

                for (int row = 0; row < rubicMatrix.Length - 1; row++)
                {
                    rubicMatrix[row][col] = rubicMatrix[row + 1][col];
                }

                rubicMatrix[rubicMatrix.Length - 1][col] = temp;
            }

        }

        private static void GetMatrix(int[][] rubicMatrix, int cols)
        {
            int counter = 1;

            for (int row = 0; row < rubicMatrix.Length; row++)
            {
                rubicMatrix[row] = new int[cols];

                for (int col = 0; col < rubicMatrix[row].Length; col++)
                {
                    rubicMatrix[row][col] = counter++;
                }
            }
        }
    }
}
