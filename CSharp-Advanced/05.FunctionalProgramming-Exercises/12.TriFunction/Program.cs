using System;
using System.Linq;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> isEqualOrLargerFunc = (word, criteria) => word.Sum(x => x) >= criteria;
            Func<string[], Func<string, int, bool>,int, string> myFunc = (names, isLargerFunc, totalSum) =>
             names.FirstOrDefault(x => isLargerFunc(x, totalSum));

            int targetSum = int.Parse(Console.ReadLine());

            string[] inputNames = Console.ReadLine().Split().ToArray();

            

            string targetName = myFunc(inputNames, isEqualOrLargerFunc, targetSum);

            Console.WriteLine(targetName);
        }
    }
}
