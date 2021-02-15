using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Variant
            //Action<string[]> print = items => Console.WriteLine(string.Join(Environment.NewLine,items));

            //string[] names = Console.ReadLine().Split().ToArray();
            //print(names);

            // 2.Variant
            //Action<string> print =Console.WriteLine;

            //Console.ReadLine().Split().ToList().ForEach(print);

            Console.ReadLine().Split().ToList().ForEach(Console.WriteLine);
        }
    }
}