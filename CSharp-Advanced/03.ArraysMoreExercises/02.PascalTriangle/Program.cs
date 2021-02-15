using System;

namespace _02.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            byte number = byte.Parse(Console.ReadLine());
            uint[] arr = { 1 };
            int n = 0;
            uint[] nextRow = new uint[arr.Length];

            while (n != number)
            {
                for (int i = 0; i < nextRow.Length; i++)
                {
                    if (i == 0)
                    {
                        nextRow[i] = arr[i];
                    }
                    else if (i == nextRow.Length - 1)
                    {
                        nextRow[i] = arr[i - 1] + 0;
                    }
                    else
                    {
                        nextRow[i] = arr[i - 1] + arr[i];
                    }
                }

                
                Console.WriteLine(string.Join(' ', nextRow));
                n++;
                arr = nextRow;
                nextRow = new uint[nextRow.Length + 1];
            }

        }
    }
}
