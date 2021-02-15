using System;
using System.Linq;

namespace FuncProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 5, 2, 7, 8, 9 };

            array = array.OrderBy(Sort).ToArray();

            Console.WriteLine(string.Join(" ", array));

        }
        static int Sort(int n)
        {
            return n;
        }
    }
}
