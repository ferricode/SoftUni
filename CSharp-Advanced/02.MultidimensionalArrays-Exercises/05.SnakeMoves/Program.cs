﻿using System;
using System.Linq;

namespace _05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            int totalRows = dimensions[0];
            int totalCols = dimensions[1];

            char[,] matrix = new char[totalRows, totalCols];

            string snakeName = Console.ReadLine();

            int counter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = snakeName[counter++];

                        if (counter == snakeName.Length)
                        {
                            counter = 0;
                        }
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {

                        matrix[row, col] = snakeName[counter++];

                        if (counter == snakeName.Length)
                        {
                            counter = 0;
                        }
                    }
                }

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
    }
}
