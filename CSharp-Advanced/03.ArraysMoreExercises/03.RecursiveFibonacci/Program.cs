using System;
using System.Collections.Generic;

namespace P5CalculateSequenceWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(getFibonacci(n, new Dictionary<int, long>()));
        }

        private static long getFibonacci(int n, Dictionary<int, long> dict)
        {
            if (n == 1 || n == 2)
                return 1;
            else
            {
                if (dict.ContainsKey(n))
                {
                    return dict[n];
                }
                else
                {
                    dict.Add(n, getFibonacci(n - 1, dict) + getFibonacci(n - 2, dict));
                    return (getFibonacci(n - 1, dict) + getFibonacci(n - 2, dict));
                }
            }

        }
    }
}
//using System;

//namespace _03.RecursiveFibonacci
//    {
//        class Program
//        {
//            static void Main(string[] args)
//            {
//                int num = int.Parse(Console.ReadLine());



//                static long recursiveFibonacci(int n)
//                {
//                    if (n <= 1)
//                    {
//                        return 1;
//                    }
//                    return recursiveFibonacci(n - 1) + recursiveFibonacci(n - 2);

//                }
//                Console.WriteLine(recursiveFibonacci(num - 1));

   