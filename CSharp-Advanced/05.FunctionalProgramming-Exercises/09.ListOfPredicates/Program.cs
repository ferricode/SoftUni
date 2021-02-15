using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> dividers = Console.ReadLine().Split().Select(int.Parse).ToList() ;

            Func<int, List<int>, List<int>> filteredNumbers = (n, dividers) =>
                   {
                       List<int> filtered = new List<int>();


                       for (int i = 1; i <= n; i++)
                       {
                           bool divisible = false;
                           for (int j = 0; j < dividers.Count; j++)
                           {
                               if (i % dividers[j] != 0)
                               {
                                   divisible = false;
                                   break;
                               }
                               else
                               {
                                   divisible = true;
                                   continue;
                               }
                           }
                           if (divisible == true)
                           {
                               filtered.Add(i);
                           }
                       }

                       return filtered;
                   };
            Console.WriteLine(string.Join(" ",filteredNumbers(n,dividers)));
        }
    }
}
