using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            int primarySum = 0;
            int secondarySum = 0;
            int absDiff = 0;
            

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                }
                primarySum += matrix[row, row];
                secondarySum += matrix[row, matrix.GetLength(0)-1 - row];
            }
            absDiff = Math.Abs(primarySum - secondarySum);
            Console.WriteLine(absDiff);

        }
    }
}
