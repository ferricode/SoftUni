using System;

namespace UsePointersCSharp
{
    class Program
    {
        static unsafe void Main(string[] args)
        {
            int x = 5;
            int* y = &x;

            Console.WriteLine((int)(&x));
            Console.WriteLine((int)y);
            Console.WriteLine((int)&y);
        }
    }
}
