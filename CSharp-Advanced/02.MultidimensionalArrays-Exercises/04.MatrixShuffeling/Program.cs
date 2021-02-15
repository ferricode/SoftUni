using System;
using System.Linq;

namespace _04.MatrixShuffeling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToArray();
            int rowsTotal = dimensions[0];
            int colsTotal = dimensions[1];

            int[,] matrix = new int[rowsTotal, colsTotal];

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

            string command = Console.ReadLine();

            while (command.ToUpper() != "END")
            {
                string[] cmdArgs = command.Split().ToArray();

                if (cmdArgs.Length == 5)
                {
                    string action = cmdArgs[0];
                    int row1 = int.Parse(cmdArgs[1]);
                    int col1 = int.Parse(cmdArgs[2]);
                    int row2 = int.Parse(cmdArgs[3]);
                    int col2 = int.Parse(cmdArgs[4]);
                    int temp = 0;

                    if (action =="swap" && row1 >= 0 && col1 >= 0 && row2 >= 0 && col2 >= 0 &&
                        row1 <=rowsTotal && col1 <=colsTotal && row2 <= rowsTotal && col2 <=colsTotal)
                    {
                        temp = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = temp;

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write(matrix[row, col]+" ");
                            }
                            Console.WriteLine();

                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                        command = Console.ReadLine();
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                    continue;
                }

                command = Console.ReadLine();

            }

        }
    }
}
