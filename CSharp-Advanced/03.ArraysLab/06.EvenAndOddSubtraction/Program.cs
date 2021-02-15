using System;
using System.Linq;

namespace _06.EvenAndOddSubtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();

            int sumEven = 0;
            int sumOdd = 0;
            int subtraction = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    sumEven += numbers[i];
                }
                else if (numbers[i] % 2 != 0)
                {
                    sumOdd += numbers[i];
                }
                subtraction = sumEven - sumOdd;
            }
            Console.WriteLine(subtraction);
        }
    }
}




