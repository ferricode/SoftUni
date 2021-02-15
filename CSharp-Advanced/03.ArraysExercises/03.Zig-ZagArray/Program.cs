using System;
using System.Linq;
namespace _03.Zig_ZagArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] firstArr = new string[n];
            string[] secondArr = new string[n];

            for (int i = 0; i < n; i++)
            {
                string[] currentArr = Console.ReadLine()
                    .Split(" ")
                    .ToArray();

                string indexZeroElement = currentArr[0];
                string indexOneElement = currentArr[1];

                //even iteration
                if (i % 2 == 0)
                {
                    firstArr[i] = indexZeroElement;
                    secondArr[i] = indexOneElement;

                }
                //odd iteration
                else if (i % 2 != 0)
                {
                    firstArr[i] = indexOneElement;
                    secondArr[i] = indexZeroElement;
                }
               
            }
            Console.WriteLine(string.Join(" ", firstArr));
            Console.WriteLine(string.Join(" ", secondArr));
        }
    }
}
