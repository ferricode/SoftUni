using System;
using System.Collections.Generic;

namespace _SortedDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, double> fruits = new SortedDictionary<string, double>()
            {
                {"orange", 2.3}
            };
            fruits.Add("banana", 3.3);
            fruits.Add("apple", 0.9);

            foreach (var item in fruits)
            {
                Console.WriteLine($"the price of {item.Key} is {item.Value}");
            }
        }
    }
}
