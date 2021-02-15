using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < rows; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int command = input[0];

                switch (command)
                {
                    case 1:
                        int number = input[1];
                        numbers.Push(number);
                        break;
                    case 2:
                        if (numbers.Any())
                        {
                            numbers.Pop();
                        }
                        break;
                    case 3:
                        if (numbers.Any())
                        {
                            Console.WriteLine(numbers.Max());
                        }
                        
                        break;
                    case 4:
                        if (numbers.Any())
                        {
                            Console.WriteLine(numbers.Min());
                        }
                        break;
                }

            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
