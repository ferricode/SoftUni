using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Stack<int> bracketIndexes = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    bracketIndexes.Push(i);
                }
                if (input[i] == ')')
                {
                    int startIndex = bracketIndexes.Pop();
                    Console.WriteLine(input.Substring(startIndex, i - startIndex+1));
                }
            }
        }
    }
}
