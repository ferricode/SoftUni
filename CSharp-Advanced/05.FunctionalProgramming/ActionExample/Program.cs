using System;

namespace ActionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printer = Print;
            printer("Oppaa");
        }
        static void Print(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
