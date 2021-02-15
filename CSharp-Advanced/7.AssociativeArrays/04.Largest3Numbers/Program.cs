using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int [] sorted=numbers.OrderByDescending(x => x).ToArray();

            if (sorted.Length<=2)
            {
                for (int i = 0; i < sorted.Length; i++)
                {
                    Console.Write(sorted[i] + " ");
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(sorted[i] + " ");
                }
            }
            
        }
    }
}
