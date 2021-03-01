using System;
using System.Collections.Generic;

namespace DemoInheritance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // var student = new Student("Ivan", "PMG");

            //var random = new RandomGenerator();
            //for (int i = 0; i < 100; i++)
            //{

            //    Console.WriteLine(random.Next(0,100));
            //}
            var hashSet = new HashSet<int>();
            hashSet.AddRange(new[] { 2, 3, 4, 5 });

            var list = new List<string>();

            var isEmpty = list.IsEmpty();
            var dict = new Dictionary<string, int>();
            dict.IsEmpty();
        }
    }
}
