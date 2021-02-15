using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.everse_AndExclude
{
    class Program
    {
        static void Main(string[] args)
        {

            Action<List<int>> printNumbers = nums => Console.WriteLine(string.Join(" ", nums));

            List<int> numbers = Console.ReadLine()
                                          .Split()
                                          .Select(int.Parse)
                                          .ToList();

            numbers.Reverse();


            int divisor = int.Parse(Console.ReadLine());

            Func<int, bool> filteredDivs = num => num % divisor != 0;

            numbers = numbers.Where(num => filteredDivs(num)).ToList();

            printNumbers(numbers);

        }
    }
}
