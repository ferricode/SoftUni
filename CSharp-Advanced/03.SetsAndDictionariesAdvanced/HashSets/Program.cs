using System;
using System.Collections.Generic;

namespace HashSets
{
    class Program
    {
        static void Main(string[] args)
        {

            HashSet<string> studentsAdvanced = new HashSet<string>();

            string input = Console.ReadLine();

            while (input!="end")
            {
                Console.WriteLine("Enter Student");
                studentsAdvanced.Add(input);
                input = Console.ReadLine();
            }
            Console.WriteLine($"Count is:{studentsAdvanced.Count}");

            while (true)
            {
                Console.WriteLine("Check if student is in course");
                input = Console.ReadLine();
                Console.WriteLine($"{studentsAdvanced.Contains(input)}");
            }

        }
    }
}
