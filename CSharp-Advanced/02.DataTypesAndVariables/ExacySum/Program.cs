using System;
using System.Numerics;

namespace ExacySum
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger n = BigInteger.Parse(Console.ReadLine());
            decimal sum = 0.0M;
               

            for (int i = 0; i < n; i++)
            {
                decimal number = decimal.Parse(Console.ReadLine());
                sum += number;
            }
            if (sum - Math.Truncate(sum) == 0)
            {
                Console.WriteLine($"{sum:f0}");
            }
            else
            {
                Console.WriteLine(sum);
            }
        }
    }
}
