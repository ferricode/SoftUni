using System;

namespace _6.Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().Split();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = int.Parse(input[col]);
                }

            }
            string command = Console.ReadLine();

            while (command != "END")
            {
                var tokens = command.Split();
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);
                if (row >=0 && col >= 0 && row<n &&col<n)
                {
                    if (tokens[0]=="Add")
                    {
                        matrix[row, col] += value;
                    }
                    else if (tokens[0] == "Subtract")
                    {
                        matrix[row, col] -= value;
                    }
                    
                }
                else
                {
                    Console.WriteLine("Invalid coordinates". );
                }

                command = Console.ReadLine();
            }
            for (int row = 0; row < n; row++)
            {
               
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
          
        }
    }
}
