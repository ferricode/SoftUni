using System;
using System.Linq;

namespace _1._SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];

            int[,] matrix = new int[rows, cols];
            int sum = 0;

            for (int row = 0; row < rows; row++)
            {
                int[] rowData = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                sum = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sum += matrix[row, col];

                }
                Console.WriteLine(sum);
            }

            
          
        }
    }
}
