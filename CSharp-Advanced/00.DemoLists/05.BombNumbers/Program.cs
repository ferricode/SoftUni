using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                       .Split()
                                       .Select(int.Parse)
                                       .ToList();

            int[] bombProp = Console.ReadLine()
                                    .Split()
                                    .Select(int.Parse)
                                    .ToArray();
            int bomb = bombProp[0];
            int power = bombProp[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNumber = numbers[i];

                if (currentNumber == bomb)
                {
                    int startindex = i - power;
                    int endIndex = i + power;

                    if (startindex < 0)
                    {
                        startindex = 0;

                    }
                    if (endIndex > numbers.Count - 1)
                    {
                        endIndex = numbers.Count - 1;
                    }

                    int endIndexToRemove = endIndex - startindex + 1;
                    numbers.RemoveRange(startindex, endIndexToRemove);
                    i = startindex - 1;
                }
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}
