using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> num = new Queue<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                num.Enqueue(numbers[i]);
            }

            int k = 0;
            foreach (var item in num)
            {
                k++;
                if (item % 2 == 0)
                {
                    Console.Write(item);
                    if (k!=num.Count)
                    {
                        Console.Write(", ");
                    }

                }
            }
            



        }
    }
}
