using System;
using System.Linq;

namespace _08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a custom comparator that sorts all even numbers before all the odd ones in ascending order. Pass it to Array.Sort() function and print the result. Use functions.
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int, int, int> myCustomComparer = (a, b) =>
              {
                  if (a % 2 == 0 && b % 2 == 0)
                  {
                      if (a < b)
                      {
                          return -1;
                      }
                      if (a > b)
                      {
                          return 1;
                      }
                      return 0;

                  }
                  if (a % 2 != 0 && b % 2 != 0)
                  {

                      if (a < b)
                      {
                          return -1;
                      }
                      if (a > b)
                      {
                          return 1;
                      }
                      return 0;
                  }
                  if (a % 2 == 0 && b % 2 != 0)
                  {
                      return -1;
                  }
                  
                  return 0;
              };
            Array.Sort(input, new Comparison<int>(myCustomComparer));
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
