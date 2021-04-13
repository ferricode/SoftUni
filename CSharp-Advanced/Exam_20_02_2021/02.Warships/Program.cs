using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];
            Queue<string> attacks = new Queue<string>(Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries).ToArray());

            int firstShips = 0;
            int secondShips = 0;
            int destroyedShips = 0;


            for (int row = 0; row < n; row++)
            {
                char[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    field[row, col] = currentRow[col];

                    if (field[row, col] == '<')
                    {
                        firstShips++;
                    }
                    else if (field[row, col] == '>')
                    {
                        secondShips++;
                    }
                }
            }


            while (attacks.Count > 0)
            {
                int[] position = attacks.Dequeue().Split(" ").Select(int.Parse).ToArray();
                int attackRow = position[0];
                int attackCol = position[1];


                if (!IsPositionValid(attackRow, attackCol, n, n))
                {
                    continue;
                }

                if (field[attackRow, attackCol] == '<' || field[attackRow, attackCol] == '>')
                {
                    switch (field[attackRow, attackCol])
                    {
                        case '<':
                            firstShips--;
                            destroyedShips++;
                            field[attackRow, attackCol] = 'X';
                            break;
                        case '>':
                            secondShips--;
                            destroyedShips++;
                            field[attackRow, attackCol] = 'X';
                            break;
                    }
                }

                if (field[attackRow, attackCol] == '#')
                {
                    if (IsPositionValid(attackRow - 1, attackCol, n, n))
                    {

                        switch (field[attackRow - 1, attackCol])
                        {
                            case '<':
                                firstShips--;
                                destroyedShips++;
                                field[attackRow - 1, attackCol] = 'X';
                                break;
                            case '>':
                                secondShips--;
                                destroyedShips++;
                                field[attackRow - 1, attackCol] = 'X';
                                break;
                        }
                    }
                    if (IsPositionValid(attackRow + 1, attackCol, n, n))
                    {

                        switch (field[attackRow + 1, attackCol])
                        {
                            case '<':
                                firstShips--;
                                destroyedShips++;
                                field[attackRow + 1, attackCol] = 'X';
                                break;
                            case '>':
                                secondShips--;
                                destroyedShips++;
                                field[attackRow + 1, attackCol] = 'X';
                                break;
                        }
                    }
                    if (IsPositionValid(attackRow, attackCol - 1, n, n))
                    {

                        switch (field[attackRow, attackCol - 1])
                        {
                            case '<':
                                firstShips--;
                                destroyedShips++;
                                field[attackRow, attackCol - 1] = 'X';
                                break;
                            case '>':
                                secondShips--;
                                destroyedShips++;
                                field[attackRow, attackCol - 1] = 'X';
                                break;
                        }
                    }
                    if (IsPositionValid(attackRow, attackCol + 1, n, n))
                    {

                        switch (field[attackRow, attackCol + 1])
                        {
                            case '<':
                                firstShips--;
                            destroyedShips++;
                            field[attackRow, attackCol + 1] = 'X';
                            break;
                            case '>':
                                secondShips--;
                            destroyedShips++;
                            field[attackRow, attackCol + 1] = 'X';
                            break;
                        }
                    }
                    if (IsPositionValid(attackRow - 1, attackCol - 1, n, n))
                    {

                        switch (field[attackRow - 1, attackCol - 1])
                        {
                            case '<':
                                firstShips--;
                                destroyedShips++;
                                field[attackRow - 1, attackCol - 1] = 'X';
                                break;
                            case '>':
                                secondShips--;
                                destroyedShips++;
                                field[attackRow - 1, attackCol - 1] = 'X';
                                break;
                        }
                    }
                    if (IsPositionValid(attackRow + 1, attackCol + 1, n, n))
                    {

                        switch (field[attackRow + 1, attackCol + 1])
                        {
                            case '<':
                                firstShips--;
                                destroyedShips++;
                                field[attackRow + 1, attackCol + 1] = 'X';
                                break;
                            case '>':
                                secondShips--;
                                destroyedShips++;
                                field[attackRow + 1, attackCol + 1] = 'X';
                                break;
                        }
                    }
                    if (IsPositionValid(attackRow + 1, attackCol - 1, n, n))
                    {

                        switch (field[attackRow + 1, attackCol - 1])
                        {
                            case '<':
                                firstShips--;
                                destroyedShips++;
                                field[attackRow + 1, attackCol - 1] = 'X';
                                break;
                            case '>':
                                secondShips--;
                                destroyedShips++;
                                field[attackRow + 1, attackCol - 1] = 'X';
                                break;
                        }
                    }
                    if (IsPositionValid(attackRow - 1, attackCol + 1, n, n))
                    {

                        switch (field[attackRow + 1, attackCol + 1])
                        {
                            case '<':
                                firstShips--;
                                destroyedShips++;
                                field[attackRow + 1, attackCol + 1] = 'X';
                                break;
                            case '>':
                                secondShips--;
                                destroyedShips++;
                                field[attackRow + 1, attackCol + 1] = 'X';
                                break;
                        }
                    }




                }
                if (firstShips == 0 || secondShips == 0)
                {
                    break;
                }


            }

            if (firstShips == 0)
            {
                Console.WriteLine($"Player Two has won the game! {destroyedShips} ships have been sunk in the battle.");

            }
            else if (secondShips == 0)
            {
                Console.WriteLine($"Player One has won the game! {destroyedShips} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {firstShips} ships left. Player Two has {secondShips} ships left.");
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
