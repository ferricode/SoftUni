using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.RemoveNegativesAndReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToList();

            //for (int i = 0; i < nums.Count; i++)
            //{
            //    if (nums[i] < 0)
            //    {
            //        nums.RemoveAt(i--);
            //    }
            //}
            //nums.RemoveAll(n => n < 0);
            //nums.Reverse();

            //if (nums.Count==0)
            //{
            //    Console.WriteLine("empty");
            //}
            //else
            //{
            //    Console.WriteLine(string.Join(" ", nums));
            //}

            List<int> result = nums
                .Where(n => n >= 0)
                .Reverse()
                .ToList();
            if (result.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}
