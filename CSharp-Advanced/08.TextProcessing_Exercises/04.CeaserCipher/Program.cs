using System;

namespace _04.CeaserCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            foreach ( char c in input)
            {
                var currentChar = (char)(c + 3);
                Console.Write(currentChar);
            }       
        }
    }
}
