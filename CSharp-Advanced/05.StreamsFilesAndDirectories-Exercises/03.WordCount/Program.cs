using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string actualResultPath = Path.Combine("..","..","..","actualResult.txt");
            string[] words = File.ReadAllLines("words.txt");
            Dictionary<string, int> wordsCounts = new Dictionary<string, int>();
            foreach (string word in words)
            {
                wordsCounts.Add(word.ToLower(), 0);
            }
            string text = File.ReadAllText("text.txt").ToLower();
            string[] textWords = text.Split(new string[] { " ", ",", ".", "!", "?", "-", Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in textWords)
            {
                if (wordsCounts.ContainsKey(word.ToLower()))
                {
                    wordsCounts[word]++;
                }
            }

            Dictionary<string, int> sortedWords = wordsCounts
                                                    .OrderByDescending(kvp => kvp.Value)
                                                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            List<string> outputLines = sortedWords.Select(kvp => $"{kvp.Key} - {kvp.Value}").ToList();

            File.WriteAllLines(actualResultPath, outputLines);
        }
    }
}
