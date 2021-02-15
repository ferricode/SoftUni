using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Dictionary<double, int> times = new Dictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (!times.ContainsKey(numbers[i]))
                {
                    times.Add(numbers[i], 0);
                }
                times[numbers[i]]++;
            }
            foreach (var time in times)
            {
                Console.Write(time.Key+" - ");
                Console.WriteLine(time.Value+ " times");
            }
        }
    }
}
