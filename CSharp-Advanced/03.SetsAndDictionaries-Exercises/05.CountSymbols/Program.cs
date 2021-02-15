using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedDictionary<char, int> charCounts = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!charCounts.ContainsKey(input[i]))
                {
                    charCounts.Add(input[i], 0);
                }
                charCounts[input[i]]++;
            }

            Console.WriteLine(string.Join(Environment.NewLine, charCounts
                .Select(k => $"{k.Key}: {k.Value} time/s" ).ToArray()));
        }
    }
}
