using System;
using System.Collections.Generic;
using System.Linq;

namespace _00.DemoListsLab
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }
    }
}
