using System;
using System.Linq;

namespace _02.SuperMario
{
    public class Program
    {
        static void Main(string[] args)
        {
            int mariosLifes = int.Parse(Console.ReadLine());
            int matrixRows = int.Parse(Console.ReadLine());

            char[][] matrix = new char[matrixRows][];

            bool marioSucceded = false;

            int marioRow = 0;
            int marioCol = 0;


            for (int rows = 0; rows < matrix.Length; rows++)
            {
                string curentLine = Console.ReadLine();
                char[] characters = curentLine.ToCharArray();
                matrix[rows] = characters;
                for (int cols = 0; cols < matrix[rows].Length; cols++)
                {
                    if (matrix[rows][cols] == 'M')
                    {
                        marioRow = rows;
                        marioCol = cols;
                    }
                }

            }


            int deadRow = 0;
            int deadCol = 0;


            while (mariosLifes > 0 && !marioSucceded)
            {
                string[] commandArgs = Console.ReadLine()
                                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                          .ToArray();
                string direction = commandArgs[0];

                int bowserRow = int.Parse(commandArgs[1]);
                int bowserCol = int.Parse(commandArgs[2]);

                matrix[bowserRow][bowserCol] = 'B';


                int currRow = marioRow;
                int currCol = marioCol;

                mariosLifes--;


                if (IsPositionValid(matrix, currRow, currCol))
                {
                    matrix[currRow][currCol] = '-';

                    currRow = MoveRow(currRow, direction);
                    currCol = MoveCol(currCol, direction);


                    if (IsPositionValid(matrix, currRow, currCol) && matrix[currRow][currCol] == 'B')
                    {
                        mariosLifes -= 2;

                        marioRow = currRow;
                        marioCol = currCol;

                        if (mariosLifes <= 0)
                        {

                            matrix[marioRow][marioCol] = 'X';

                            deadRow = currRow;
                            deadCol = currCol;
                            break;
                        }

                    }
                    else if (IsPositionValid(matrix, currRow, currCol) && matrix[currRow][currCol] == 'P')
                    {
                        marioSucceded = true;
                        
                        matrix[currRow][currCol] = '-';
                        break;
                    }

                    matrix[currRow][currCol] = 'M';
                    marioRow = currRow;
                    marioCol = currCol;
                }
            }

            if (mariosLifes <= 0)
            {
                Console.WriteLine($"Mario died at {deadRow};{deadCol}.");
            }
            else if (marioSucceded)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {mariosLifes}");
            }

            for (int rows = 0; rows < matrix.Length; rows++)
            {
                for (int cols = 0; cols < matrix[rows].Length; cols++)
                {
                    Console.Write($"{matrix[rows][cols]}");
                }
                Console.WriteLine();
            }

        }

        public static int MoveRow(int row, string movement)
        {
            if (movement == "W")
            {
                return row - 1;
            }
            if (movement == "S")
            {
                return row + 1;
            }
            return row;
        }

        public static int MoveCol(int col, string movement)
        {
            if (movement == "A")
            {
                return col - 1;
            }
            if (movement == "D")
            {
                return col + 1;
            }
            return col;
        }
        public static bool IsPositionValid(char[][] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.Length)
            {
                if (col >= 0 && col < matrix[row].Length)
                {
                    return true;
                }
            }
            return false;
        }

    }
}