using System;

namespace MutableObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            MutableList list = new MutableList(new string[] { "Bubi", "Bu", "Buchko" });
           // list.StudentNames[0] = "Neee";

            foreach (var name in list.StudentNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
