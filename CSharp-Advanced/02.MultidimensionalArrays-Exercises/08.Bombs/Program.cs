using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Bombs
{
    class Program
    {
        static int[,] matrix;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            matrix = new int[n, n];
            int aliveCells = 0;
            int sumCells = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }

            }
            string[] inputBombs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            Queue<string> bombs = new Queue<string>(inputBombs);

            while (bombs.Any())
            {
                int[] coordinates = bombs.Dequeue()
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int x = coordinates[0];
                int y = coordinates[1];
                int bomb = matrix[x, y];

                if (bomb < 0)
                {
                    continue;
                }
                    for (int row = x - 1; row <= x + 1; row++)
                    {

                        for (int col = y - 1; col <= y + 1; col++)
                        {

                            if (IsInside(row, col) && matrix[row, col] > 0)
                            {

                                matrix[row, col] -= bomb;
                            }

                        }

                    }
                

            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        sumCells += matrix[row, col];
                    }


                }

            }
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumCells}");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();

            }
        }
        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }
    }
}
