using System;
using System.Collections.Generic;

namespace _05.DigitLettersOthers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] output = input.ToCharArray();

            List<char> digitis = new List<char>();
            List<char> letter = new List<char>();
            List<char> other = new List<char>();

            foreach (var c in output)
            {
                if (char.IsDigit(c))
                {
                    Console.Write(c);
                }
               
            }
            Console.WriteLine();
            foreach (var c in output)
            {
                if (char.IsLetter(c))
                {
                    Console.Write(c);
                }
            }
            Console.WriteLine();
            foreach (var c in output)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    Console.Write(c);
                }
            }


        }
    }
}
