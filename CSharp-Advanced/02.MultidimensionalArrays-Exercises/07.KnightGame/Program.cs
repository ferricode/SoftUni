using System;

namespace _07.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] chessBoard = new char[size, size];

            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    chessBoard[row, col] = input[col];
                }

            }

            int knightsCount = 0;
            int killerRow = 0;
            int killerCol = 0;

            while (true)
            {
                int maxAtacks = 0;

                for (int row = 0; row < chessBoard.GetLength(0); row++)
                {
                    for (int col = 0; col < chessBoard.GetLength(1); col++)
                    {
                        int currentKnightesAttacks = 0;

                        if (chessBoard[row, col] == 'K')
                        {
                            //-2 1 
                            if (IsInside(chessBoard, row - 2, col + 1) && chessBoard[row - 2, col + 1] == 'K')
                            {
                                currentKnightesAttacks++;
                            }
                            //-2 -1 
                            if (IsInside(chessBoard, row - 2, col - 1) && chessBoard[row - 2, col - 1] == 'K')
                            {
                                currentKnightesAttacks++;
                            }
                            //-1 2 
                            if (IsInside(chessBoard, row - 1, col + 2) && chessBoard[row - 1, col + 2] == 'K')
                            {
                                currentKnightesAttacks++;
                            }
                            //-1 -2 
                            if (IsInside(chessBoard, row - 1, col - 2) && chessBoard[row - 1, col - 2] == 'K')
                            {
                                currentKnightesAttacks++;
                            }
                            // 1 2 
                            if (IsInside(chessBoard, row + 1, col + 2) && chessBoard[row + 1, col + 2] == 'K')
                            {
                                currentKnightesAttacks++;
                            }
                            // 1 -2 
                            if (IsInside(chessBoard, row + 1, col - 2) && chessBoard[row + 1, col - 2] == 'K')
                            {
                                currentKnightesAttacks++;
                            }
                            //2 1 
                            if (IsInside(chessBoard, row + 2, col + 1) && chessBoard[row + 2, col + 1] == 'K')
                            {
                                currentKnightesAttacks++;
                            }
                            //2 -1 
                            if (IsInside(chessBoard, row + 2, col - 1) && chessBoard[row + 2, col - 1] == 'K')
                            {
                                currentKnightesAttacks++;
                            }

                            if (currentKnightesAttacks > maxAtacks)
                            {
                                maxAtacks = currentKnightesAttacks;
                                killerRow = row;
                                killerCol = col;

                            }

                        }
                    }
                }
                if (maxAtacks > 0)
                {
                    chessBoard[killerRow, killerCol] = '0';
                    knightsCount++;
                }
                else
                {
                    Console.WriteLine(knightsCount);
                    break;
                }
            }
        }

        private static bool IsInside(char[,] chessBoard, int row, int col)
        {
            return row >= 0 && row < chessBoard.GetLength(0) &&
                col >= 0 && col < chessBoard.GetLength(1);
        }
    }
}
