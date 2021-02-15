using System;
using System.Collections.Generic;

namespace _00.DemoLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> myList = new List<string> { "Georgi", "Maria", "Peter"};
            myList.Add("Ivan");
            myList.Insert(1, "Strahil");
            myList.Remove("Maria");

            Console.WriteLine((myList.Count));
            Console.WriteLine(string.Join(" ", myList));
        }
    }
}
