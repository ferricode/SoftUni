using System;
using System.Linq;

namespace _00.DemoArraysExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

        }
    }
}
