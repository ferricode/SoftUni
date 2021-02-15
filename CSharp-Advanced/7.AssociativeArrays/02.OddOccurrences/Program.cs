using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> counts = new Dictionary<string, int>();
            string[] words = Console.ReadLine()
                                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                            .ToArray();
            foreach (var word in words)
            {
                string wordInLower = word.ToLower();
                if (counts.Keys.Contains(wordInLower))
                {
                    counts[wordInLower]++;
                }
                else
                {
                    counts.Add(wordInLower, 1);
                }
            }

            foreach (var count in counts)
            {
                if (count.Value % 2 != 0)
                {
                    Console.Write(count.Key+" ");
                }
            }
        }
    }
}
