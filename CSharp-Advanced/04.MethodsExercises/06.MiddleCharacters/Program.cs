using System;

namespace _06.MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string output = string.Empty;
            //even
            if (input.Length % 2 == 0)
            {

                output = GetMiddleCharEvenStringLenght(input);
                Console.WriteLine(output);
            }
            //odd
            else
            {
                output = GetMiddleCharOddStringLenght(input);
                Console.WriteLine(output);
            }
        }

        private static string GetMiddleCharOddStringLenght(string input)
        {
            int index = input.Length / 2;
            string chars = input.Substring(index, 1);
            return chars;
        }

        private static string GetMiddleCharEvenStringLenght(string input)
        {
            int index = input.Length / 2;
            string chars = input.Substring(index - 1, 2);
            return chars;
        }
    }
}
