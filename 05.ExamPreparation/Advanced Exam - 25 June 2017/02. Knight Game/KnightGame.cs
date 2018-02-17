using System;
using System.Data;
using System.Runtime.InteropServices;

namespace _02._Knight_Game
{
    class KnightGame
    {
        static void Main()
        {
            var boardSize = int.Parse(Console.ReadLine());
            var board = new char[boardSize][];

            for (int row = 0; row < board.Length; row++)
            {
                board[row] = Console.ReadLine().ToCharArray();
            }
            int maxRow = 0;
            int maxCol = 0;
            int maxAttaked = 0;
            int counter = 0;
            do
            {

                if (maxAttaked > 0)
                {
                    board[maxRow][maxCol] = '0';
                    maxAttaked = 0;
                    counter++;
                }
                int currentAtack = 0;
                for (int row = 0; row < board.Length; row++)
                {
                    for (int col = 0; col < board.Length; col++)
                    {
                        if (board[row][col] == 'K')
                        {
                            currentAtack = Calculate(row, col, board);
                            if (currentAtack > maxAttaked)
                            {
                                maxAttaked = currentAtack;
                                maxRow = row;
                                maxCol = col;
                            }
                        }
                    }
                }

            } while (maxAttaked > 0);

            Console.WriteLine(counter);
        }

        static int Calculate(int row, int col, char[][] board)
        {
            var atack = 0;
            if (isPositionKnight(row - 2, col - 1, board)) atack++;
            if (isPositionKnight(row - 2, col + 1, board)) atack++;
            if (isPositionKnight(row - 1, col - 2, board)) atack++;
            if (isPositionKnight(row - 1, col + 2, board)) atack++;
            if (isPositionKnight(row + 2, col - 1, board)) atack++;
            if (isPositionKnight(row + 2, col + 1, board)) atack++;
            if (isPositionKnight(row + 1, col - 2, board)) atack++;
            if (isPositionKnight(row + 1, col + 2, board)) atack++;

            return atack;
        }

        static bool isPositionKnight(int row, int col, char[][] board)
        {
            return IsAtakedInBoard(row, col, board[0].Length)
                   && board[row][col] == 'K';
        }


        static bool IsAtakedInBoard(int row, int col, int boardSize)
        {
            return row >= 0 && row < boardSize && col >= 0 && col < boardSize;
        }
    }
}
