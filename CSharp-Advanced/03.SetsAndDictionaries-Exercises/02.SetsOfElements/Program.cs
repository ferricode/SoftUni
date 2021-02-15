using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = input[0];
            int m = input[1];

            HashSet<string> hashSetN = new HashSet<string>();
            HashSet<string> hashSetM = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                hashSetN.Add(Console.ReadLine());

            }
            for (int i = 0; i < m; i++)
            {
                hashSetM.Add(Console.ReadLine());

            }

            hashSetN.IntersectWith(hashSetM);

            Console.WriteLine(string.Join(" ", hashSetN));
        }
    }
}
