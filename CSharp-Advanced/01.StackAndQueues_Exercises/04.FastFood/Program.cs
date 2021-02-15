using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalFood = int.Parse(Console.ReadLine());
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> orders = new Queue<int>(input);

            Console.WriteLine(orders.Max());

            for (int i = 0; i < input.Length; i++)
            {
                int food = orders.Peek();

                if (totalFood >= food)
                {
                    totalFood -= food;
                    orders.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: " + string.Join(" ", orders));
                    break;
                }
            }
            if (!orders.Any())
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
