using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();

            // Func<string, bool> func = name => name.Length <= length;
            Func<string, int, bool> func = (name,length) => name.Length <= length;

            //names = names.Where(func).ToList();
            names = names.Where(name=>func(name, length)).ToList();

            // names = names.Where(name => name.Length <= length).ToList();

            Action<List<string>> print = names => Console.WriteLine(string.Join(Environment.NewLine, names));

            print(names);
           

           
        }
    }
}
