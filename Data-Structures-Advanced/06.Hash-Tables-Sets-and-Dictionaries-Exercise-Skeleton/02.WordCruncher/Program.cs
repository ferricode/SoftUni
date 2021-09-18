using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.WordCruncher
{

    class Cruncher
    {
        private class Node
        {
            private string[] syllables;
            private object nextSyllables;

            public Node(string syllable, List<Node> nextSyllables)
            {
                Syllable = syllable;
                NextSyllables = nextSyllables;
            }

            public string Syllable { get; set; }
            public List<Node> NextSyllables { get; set; }
        }
        private List<Node> syllableGroups;
        public Cruncher(string[] syllables, string targetWord)
        {
            this.syllableGroups = new List<Node>();
            this.syllableGroups = this.GenerateSyllableGroups(syllables, targetWord);
        }

        private List<Node> GenerateSyllableGroups(string[] syllables, string targetWord)
        {
            if (string.IsNullOrEmpty(targetWord) || syllables.Length == 0)
            {
                return null;
            }
            var resultValues = new List<Node>();
            for (int i = 0; i < syllables.Length; i++)
            {
                var syllable = syllables[i];

                if (targetWord.StartsWith(syllable))
                {
                    var nextSyllables = this.GenerateSyllableGroups(
                        syllables.Where((_, index) => index != i).ToArray(),
                       targetWord.Substring(syllable.Length)
                        );

                    resultValues.Add(new Node(syllable, nextSyllables));

                }
            }

            return resultValues;
        }
        public HashSet<string> GetSyllablePaths()
        {
            var allPaths = new List<List<string>>();

            ReconstructPaths(this.syllableGroups, new Stack<string>(), allPaths);

            return new HashSet<string>(allPaths.Select(list => string.Join(' ', list)));
        }

        private void ReconstructPaths(List<Node> nodes, Stack<string> currentPath, List<List<string>> allPaths)
        {
            if (nodes==null)
            {
                allPaths.Add(new List<string>(currentPath.Reverse()));
                return;
            
            }
            foreach (var node in nodes)
            {
                currentPath.Push(node.Syllable);

                ReconstructPaths(node.NextSyllables, currentPath, allPaths);
                currentPath.Pop();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var syllables = Console.ReadLine().Split(", ");
            var targetWord = Console.ReadLine();

            var cruncher = new Cruncher(syllables, targetWord);
            foreach (var syllablePath in cruncher.GetSyllablePaths())
            {
                Console.WriteLine(syllablePath);
            }
        }
    }
}
