using System;
using System.Collections.Generic;
using System.Linq;

namespace P06_Target_Practice
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            char[][] matrix = new char[rows][];

            string input = Console.ReadLine();

            GetMatrix(matrix, cols, input);

            int[] shot = Console.ReadLine().Split().Select(int.Parse).ToArray();

            MakeShot(matrix, shot);

            Rearrange(matrix);

            Print(matrix);
        }

        private static void Rearrange(char[][] matrix)
        {
            

            Queue<char> queue = new Queue<char>(matrix.Length);

            for (int col = 0; col < matrix[0].Length; col++)
            {
                int counter = 0;

                for (int row = 0; row < matrix.Length; row++)
                {
                    if (matrix[row][col] != ' ')
                    {
                        queue.Enqueue(matrix[row][col]);
                    }
                    else
                    {
                        counter++;
                    }
                }

                for (int row = 0; row < counter; row++)
                {
                    matrix[row][col] = ' ';
                }

                for (int row = counter; row < matrix.Length; row++)
                {
                    matrix[row][col] = queue.Dequeue();
                }
            }
        }

        private static void MakeShot(char[][] matrix, int[] shot)
        {
            int targetRow = shot[0];
            int targetCol = shot[1];
            int radius = shot[2];

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    bool isInside = Math.Pow((targetRow - row), 2) + Math.Pow((targetCol - col), 2) <= Math.Pow(radius, 2);

                    if (isInside)
                    {
                        matrix[row][col] = ' ';
                    }
                }

            }

        }

        private static void Print(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }

                Console.WriteLine();
            }
        }

        private static void GetMatrix(char[][] matrix, int cols, string input)
        {
            bool isLeft = true;
            int counter = 0;

            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                matrix[row] = new char[cols];

                if (isLeft)
                {
                    for (int col = matrix[row].Length - 1; col >= 0; col--)
                    {
                        if (counter >= input.Length)
                        {
                            counter = 0;
                        }
                        matrix[row][col] = input[counter++];

                    }

                    isLeft = false;
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (counter >= input.Length)
                        {
                            counter = 0;
                        }
                        matrix[row][col] = input[counter++];
                    }

                    isLeft = true;
                }
            }
        }
    }
}
