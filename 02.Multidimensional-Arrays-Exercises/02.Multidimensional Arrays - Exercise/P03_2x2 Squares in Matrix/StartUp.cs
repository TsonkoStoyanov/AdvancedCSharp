using System;
using System.Linq;

namespace P03_2x2_Squares_in_Matrix
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                                 .Select(int.Parse)
                                                 .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];


            char[][] matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                char[] inputRow = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                                    .Select(char.Parse)
                                                    .ToArray();

                matrix[row] = inputRow;
            }

            int count = 0;

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[row].Length - 1; col++)
                {
                    bool isEqual = matrix[row][col] == matrix[row][col + 1] && matrix[row][col] == matrix[row + 1][col]
                                                                            && matrix[row][col] == matrix[row + 1][col + 1];
                    if (isEqual)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
