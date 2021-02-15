using System;

namespace _05.AddandSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            
            int sum = Sum(firstNumber, secondNumber, thirdNumber);

            Console.WriteLine(sum);
        }

        private static int Sum(int firstNumber, int secondNumber, int thirdNumber)
        {
            int sumFirstAndSecond = firstNumber + secondNumber;
            return Subtract(sumFirstAndSecond,thirdNumber);
        }

        private static int Subtract(int sumFirstAndSecond, int thirdNumber)
        {
            return  sumFirstAndSecond - thirdNumber;
            
        }
    }
}
