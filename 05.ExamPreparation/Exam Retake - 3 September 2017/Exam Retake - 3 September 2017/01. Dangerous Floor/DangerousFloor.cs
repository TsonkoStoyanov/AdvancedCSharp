using System;
using System.Linq;

namespace _01._Dangerous_Floor
{
    class DangerousFloor
    {
        static void Main()
        {
            char[][] board = new char[8][];

            for (int row = 0; row < board.Length; row++)
            {
                board[row] = Console.ReadLine().Split(',').Select(char.Parse).ToArray();
            }

            var command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                var figureType = command[0];
                var startingRow = int.Parse(command[1].ToString());
                var startingCol = int.Parse(command[2].ToString());
                var targetRow = int.Parse(command[4].ToString());
                var targetCol = int.Parse(command[5].ToString());

                if (!FigureExist(figureType, startingRow, startingCol, board))
                {
                    Console.WriteLine($"There is no such a piece!");
                    continue;
                }
                if (!IsMoveValid(figureType, startingRow, startingCol, targetRow, targetCol))
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }

                if (!OutOfBoard(targetCol, targetRow))
                {
                    Console.WriteLine($"Move go out of board!");
                    continue;
                }

                board[targetRow][targetCol] = figureType;
                board[startingRow][startingCol] = 'x';
            }

        }

        static bool OutOfBoard(int targetCol, int targetRow)
        {
            return targetRow >= 0 && targetRow <= 7 && targetCol >= 0 && targetCol <= 7;
        }

        static bool IsMoveValid(char figureType, int startingRow, int startingCol, int targetRow, int targetCol)
        {
            switch (figureType)
            {
                case 'P':
                    return ValidPawnMove(startingRow, startingCol, targetRow, targetCol);
                case 'R':
                    return ValidRockMove(startingRow, startingCol, targetRow, targetCol);
                case 'B':
                    return ValidBishopMove(startingRow, startingCol, targetRow, targetCol);
                case 'Q':
                    return ValidRockMove(startingRow, startingCol, targetRow, targetCol)
                        || ValidBishopMove(startingRow, startingCol, targetRow, targetCol);
                case 'K':
                    return ValidKingMove(startingRow, startingCol, targetRow, targetCol);

                default:
                    return false;
            }
        }

        static bool ValidKingMove(int startingRow, int startingCol, int targetRow, int targetCol)
        {
            bool row = Math.Abs(startingRow - targetRow) == 1 || Math.Abs(startingRow - targetRow) == 0;
            bool col = Math.Abs(startingCol - targetCol) == 1 || Math.Abs(startingCol - targetCol) == 0;

            return row && col;
        }

        static bool ValidBishopMove(int startingRow, int startingCol, int targetRow, int targetCol)
        {
            return Math.Abs(startingRow - targetRow) == Math.Abs(startingCol - targetCol);
        }

        static bool ValidRockMove(int startingRow, int startingCol, int targetRow, int targetCol)
        {
            bool sameRow = startingRow == targetRow;
            bool sameCol = startingCol == targetCol;
            return sameRow || sameCol;
        }

        static bool ValidPawnMove(int startingRow, int startingCol, int targetRow, int targetCol)
        {
            bool validCol = startingCol == targetCol;
            bool validRow = startingRow - 1 == targetRow;
            return validCol && validRow;
        }

        static bool FigureExist(char figureType, int startingRow, int startingCol, char[][] board)
        {
            return figureType == board[startingRow][startingCol];
        }
    }
}
