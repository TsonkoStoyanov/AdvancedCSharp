
using System;

namespace P01_Matrix_of_Palindromes
{
    class StartUp
    {
        static void Main(string[] args)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            var input = Console.ReadLine().Split();

            int row = int.Parse(input[0]);
            int col = int.Parse(input[1]);

            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    Console.Write($"{alphabet[r]}{alphabet[r+c]}{alphabet[r]} ");
                }

                Console.WriteLine();
            }



        }
    }
}
