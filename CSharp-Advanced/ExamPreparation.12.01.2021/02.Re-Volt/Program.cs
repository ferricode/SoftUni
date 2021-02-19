using System;

namespace _02.Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int count = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int playerRow = 0;
            int playerCol = 0;

            bool isFinished = false;

            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            while (count > 0)
            {
               
                string input = Console.ReadLine();
                matrix[playerRow, playerCol] = '-';

                int playerRowStart = playerRow;
                int playerColStart = playerCol;
                playerRow = MoveRowRe(playerRow, n, input);
                playerCol = MoveColRe(playerCol, n, input);

                if (matrix[playerRow, playerCol] == 'F')
                {
                    matrix[playerRow, playerCol] = 'f';
                    isFinished = true;
                    break;
                }
                switch (matrix[playerRow, playerCol])
                {
                    case 'B':
                        playerRow = MoveRowRe(playerRow, n, input);
                        playerCol = MoveColRe(playerCol, n, input);
                        break;
                    case 'T':
                        playerRow = playerRowStart;
                        playerCol = playerColStart;
                        break;

                }
                matrix[playerRow, playerCol] = 'f';
                count--;
            }
            if (isFinished)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }

        }
        public static int MoveRowRe(int row, int n, string movement)
        {
            if (movement == "up")
            {
                if (row - 1 < 0)
                {
                    return n-1;
                }
                return row - 1;
            }
            if (movement == "down")
            {
                if (row + 1 > n)
                {
                    return 0;
                }
                return row + 1;
            }
            return row;
        }
        public static int MoveColRe(int col, int n, string movement)
        {
            if (movement == "left")
            {
                if (col - 1 < 0)
                {
                    return n-1;
                }
                return col - 1;
            }
            if (movement == "right")
            {
                if (col + 1 > n)
                {
                    return 0;
                }
                return col + 1;
            }
            return col;
        }


    }
}
