using System;

namespace Enumarations
{
    class Program
    {
        static void Main(string[] args)
        {
            Size shirtSize = Size.L;
            Shirt shirt = new Shirt();

            shirt.Size = shirtSize;
            Console.WriteLine((int)shirtSize);
            Console.WriteLine((int)Size.S);
            Console.WriteLine((int)Size.M);
            Console.WriteLine((int)Size.L);
        }
    }
}
