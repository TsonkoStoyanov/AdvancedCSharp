using System;
using System.Linq;

namespace P02_Diagonal_Difference
{
    class StartUp
    {
        static void Main()
        {
            int sizes = int.Parse(Console.ReadLine());

            int[][] matrix = new int[sizes][];

            for (int row = 0; row < matrix.Length; row++)
            {
                int[] rowInput = Console.ReadLine().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries)
                                                   .Select(int.Parse)
                                                   .ToArray();
                matrix[row] = rowInput;
                
            }

            int primary = 0;
            int secondary = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                primary += matrix[row][row];
                secondary += matrix[row][sizes - row - 1];
            }

            int result = Math.Abs(primary - secondary);

            Console.WriteLine(result);
        }
    }
}
