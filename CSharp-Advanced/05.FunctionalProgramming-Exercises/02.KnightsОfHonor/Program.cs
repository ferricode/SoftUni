using System;
using System.Linq;

namespace _02.KnightsОfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = items=> Console.WriteLine((string.Join(Environment.NewLine, "Sir "+ items)));

            Console.ReadLine().Split().ToList().ForEach(print);
        }
    }
}
