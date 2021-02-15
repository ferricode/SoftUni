﻿using System;

namespace _08.FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            
            double factorialFirstNumber = GetFactorial(firstNumber);
            double factorialSecondNumber = GetFactorial(secondNumber);

            double result = factorialFirstNumber / factorialSecondNumber;
            Console.WriteLine($"{result:f2}");
;        }

        private static double GetFactorial(int number)
        {
            double result = 1;
            while (number != 1)
            {
                result = result * number;
                number = number - 1;
            }
            return result;
        }
    }
}
