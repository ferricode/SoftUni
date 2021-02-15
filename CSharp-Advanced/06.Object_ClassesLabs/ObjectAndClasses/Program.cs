using System;

namespace ObjectAndClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dice dice6 = new Dice();

            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine(dice6.Roll());
            }
        }
    }
}
