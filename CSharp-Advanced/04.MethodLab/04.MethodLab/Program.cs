using System;

namespace _04.MethodDemo
{
    class Program
    {
        static void Main(string[] args)
        {


            PrintString("", 7);
        }

        private static void PrintString(string str, int count)
        {
            PrintString(str, count);
        }
    }
}
