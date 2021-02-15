﻿using System;

namespace SumOfRowsAndCols
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0;row < n;row++)
            {
                for (int col = 0; col <n; col++)
                {
                    matrix[row, col] = row + col;
                }
            }
        }
    }
}
