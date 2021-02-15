using System;

namespace _07.RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());

            RepeatString(input, number);

        }

        private static void RepeatString(string input, int number)
        {
            for (int i = 0; i < number; i++)
            {
                Console.Write(input);
            }
            Console.WriteLine();
        }
    }
}
