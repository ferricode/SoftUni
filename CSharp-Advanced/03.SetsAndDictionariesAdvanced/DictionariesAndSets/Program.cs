using System;
using System.Collections.Generic;

namespace DictionariesAndSets
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 3, 4, 4 };
            Console.WriteLine(array[0]);

            Dictionary<string, int> studentsAges = new Dictionary<string, int>();

            studentsAges.Add("Gogi", 38);
            studentsAges.Add("Dorotea", 19);

            Console.WriteLine(studentsAges["Gogi"]);
        }
    }
}
