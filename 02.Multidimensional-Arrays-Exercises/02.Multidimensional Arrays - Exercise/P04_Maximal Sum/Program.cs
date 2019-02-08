using System;
using System.Linq;

namespace P04_Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[][] matrix = new int[dimensions[0]][];

            for (int row = 0; row < matrix.Length; row++)
            {
                int[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                matrix[row] = input;


            }

            int maxSum = 0;
            int rowIndex = 0;
            int colIndex = 0;

            for (int row = 0; row < matrix.Length - 2; row++)
            {
                int sum = 0;
                for (int col = 0; col < matrix[row].Length - 2; col++)
                {
                    sum = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2] +
                          matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2] +
                          matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        rowIndex = row;
                        colIndex = col;
                    }


                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = rowIndex; row <= rowIndex + 2; row++)
            {
                for (int col = colIndex; col <= colIndex + 2; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
