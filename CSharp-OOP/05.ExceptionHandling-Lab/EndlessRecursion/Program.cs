using System;

namespace EndlessRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Recursion();
            }
            catch (StackOverflowException ex)
            {
                Console.WriteLine(ex.Message + "Stackoverflow is bad");
            }
            Console.WriteLine("After exception");
        }

        static void Recursion()
        {
            throw new StackOverflowException();
        }
    }
}
