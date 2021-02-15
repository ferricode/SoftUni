using System;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];


            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            int sellerRow = 0;
            int sellerCol = 0;

            for (int row = 0; row < n; row++)
            {


                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        sellerRow = row;
                        sellerCol = col;
                        break;
                    }
                }
            }

            int money = 0;


            while (IsPositionValid(sellerRow, sellerCol, n, n) && money < 50)
            {
                string input = Console.ReadLine();
                matrix[sellerRow, sellerCol] = '-';

                sellerRow = MoveRow(sellerRow, input);
                sellerCol = MoveCol(sellerCol, input);

                if (!IsPositionValid(sellerRow, sellerCol, n, n))
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    break;
                }
                if (char.IsDigit(matrix[sellerRow, sellerCol]))
                {

                    money += int.Parse(matrix[sellerRow, sellerCol].ToString());
                }
                if (matrix[sellerRow, sellerCol] == 'O')
                {
                    matrix[sellerRow, sellerCol] = '-';
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (matrix[row, col] != matrix[sellerRow, sellerCol] && matrix[row, col] == 'O')
                            {
                                sellerRow = row;
                                sellerCol = col;
                            }
                        }

                    }
                }


                matrix[sellerRow, sellerCol] = 'S';

            }
            if (money > 50)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {money}");


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
        public static int MoveRow(int row, string movement)
        {
            if (movement == "up")
            {
                return row - 1;
            }
            if (movement == "down")
            {
                return row + 1;
            }
            return row;
        }
        public static int MoveCol(int col, string movement)
        {
            if (movement == "left")
            {
                return col - 1;
            }
            if (movement == "right")
            {
                return col + 1;
            }
            return col;
        }

        public static bool IsPositionValid(int row, int col, int rows, int cols)
        {
            if (row < 0 || row >= rows)
            {
                return false;
            }
            if (col < 0 || col >= cols)
            {
                return false;
            }
            return true;

        }
    }
}