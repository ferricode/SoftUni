using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimension = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int n = dimension[0];
            int m = dimension[1];
            int[,] matrix = new int[n, m];


            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = 0;
                }
            }
            string command = Console.ReadLine();

            while (command != "Bloom Bloom Plow")
            {
                int[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int plantRow = cmdArgs[0];
                int plantCol = cmdArgs[1];

                if (IsPositionValid(plantRow, plantCol, n, m))
                {
                    for (int row = 0; row < n; row++)
                    {
                        matrix[row, plantCol]++;

                    }
                    for (int col = 0; col < n; col++)
                    {
                        if (plantCol != col)
                        {

                            matrix[plantRow, col]++;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                command = Console.ReadLine();
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]+" ");
                }

                Console.WriteLine();
            }
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
