using System;
using System.Linq;

namespace _04.ReverseArrayOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(' ', Console.ReadLine()
                .Split()
                .Reverse()));
        }
    }
}
