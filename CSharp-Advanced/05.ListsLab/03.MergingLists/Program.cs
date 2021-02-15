using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstNumbers = Console.ReadLine()
              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToList();

            List<int> secondNumbers = Console.ReadLine()
             .Split(" ", StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse)
             .ToList();

            List<int> result = new List<int>();
            for (int i = 0; i < Math.Min(firstNumbers.Count,secondNumbers.Count); i++)
            {
                result.Add(firstNumbers[i]);
                result.Add(secondNumbers[i]);
            }

            for (int i = Math.Min(firstNumbers.Count, secondNumbers.Count); i < Math.Max(firstNumbers.Count, secondNumbers.Count); i++)
            {
                if (i>=firstNumbers.Count)
                {
                    result.Add(secondNumbers[i]);
                }
                else
                {
                    result.Add(firstNumbers[i]);
                }
            }
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
