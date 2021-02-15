using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 4 3 2 1 7 13


            //Func<int[], int> minFunc = inputNumbers =>
            //     {
            //         int minValue = int.MaxValue;
            //         foreach (var currentNumber in inputNumbers)
            //         {
            //             if (currentNumber < minValue)
            //             {
            //                 minValue = currentNumber;
            //             }
            //         }
            //         return minValue;
            //     };

            //int[] numbers = Console.ReadLine()
            //                 .Split()
            //                 .Select(int.Parse)
            //                 .ToArray();

            //int result = minFunc(numbers);
            //Console.WriteLine(result);

            int number = Console.ReadLine()
                             .Split()
                             .Select(int.Parse)
                             .MyMin();


            Console.WriteLine(number);
        }
        
    }
}

