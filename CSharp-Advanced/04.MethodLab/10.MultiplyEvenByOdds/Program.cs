using System;

namespace _10.MultiplyEvenByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            number = Math.Abs(number);
            long[] numbers = new long[number.ToString().Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[numbers.Length - i - 1] = number % 10;
                number /= 10;
            }
            Console.WriteLine(GetMultipleOfEvenAndOdds(numbers));
        }

        private static long GetMultipleOfEvenAndOdds(long[] numbers)
        {
            long result = GetSumOfEvenDigits(numbers) * GetSumOfOddDigits(numbers);
            return result;
        }

        private static long GetSumOfOddDigits(long[] numbers)
        {
            long sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 != 0)
                {
                    sum += numbers[i];
                }
            }
            return sum;
        }

        private static long GetSumOfEvenDigits(long[] numbers)
        {
            long sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    sum += numbers[i];
                }

            }
            return sum;
        }
    }
}
