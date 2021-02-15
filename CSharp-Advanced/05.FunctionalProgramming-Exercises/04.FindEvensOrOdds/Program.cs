using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            //Predicate<int> isEvenPredicate = num => num % 2 == 0;

            Func<int, bool> isEvenFunc = myNum => myNum % 2 == 0;
            Action<List<int>> printNumbers = nums => Console.WriteLine(string.Join(separator: " ", nums));
            int[] input = Console.ReadLine()
                             .Split()
                             .Select(int.Parse)
                             .ToArray();

            List<int> numbers = new List<int>();
            int startNumber = input[0];
            int endNumber = input[1];

            for (int i = startNumber; i <= endNumber; i++)
            {
                numbers.Add(i);
            }

            string numberType = Console.ReadLine();

            List<int> result
= new List<int>();

            if (numberType == "even")
            {
                //numbers.RemoveAll(match:x=>!isEvenPredicate(x));
                result = numbers.Where(isEvenFunc).ToList();
            }
            else
            {
                // numbers.RemoveAll(match: x => isEvenPredicate(x));

                result = numbers.Where(x => !isEvenFunc(x)).ToList();
            }

            //printNumbers(numbers);
            printNumbers(result);

        }
    }
}
