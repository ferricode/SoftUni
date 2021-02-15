using System;
using System.Collections.Generic;

namespace _01.CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            Dictionary<char, int> occurences = new Dictionary<char, int>();

            foreach (var letter in input)
            {
                if (letter != ' ')
                {

                    if (!occurences.ContainsKey(letter))
                    {
                        occurences.Add(letter, 0);
                    }
                    occurences[letter]++;
                }
            }
            foreach (var c in occurences)
            {
                char currentKey = c.Key;
                int currentValue = c.Value;
                Console.WriteLine($"{currentKey} -> {currentValue}");
            }

        }
    }
}
