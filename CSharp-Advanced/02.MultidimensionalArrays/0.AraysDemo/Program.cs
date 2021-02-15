using System;

namespace _6.Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] jaggedArray = new int[3][];

            jaggedArray[0] = new int[2];
            jaggedArray[1] = new int[1];
            jaggedArray[2] = new int[3];

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    jaggedArray[row][col] = int.Parse(Console.ReadLine());
                }
            }
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.WriteLine(jaggedArray[row][col] + " ");
                }
            }
        }
    }
}
