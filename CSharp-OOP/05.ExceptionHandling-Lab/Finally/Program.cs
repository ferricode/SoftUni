using System;

namespace Finally
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    int age = int.Parse(Console.ReadLine());
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Inside catch");
            //    throw e;
            //}
            //finally
            //{
            //    Console.WriteLine("This always gets executed");
            //}

            static void TestTryFinally()
            {
                Console.WriteLine("Code executed before try-finally.");
                try
                {
                    string str = Console.ReadLine();
                    int.Parse(str);
                    Console.WriteLine("Parsing was successful.");
                    return; // Exit from the current method }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Parsing failed!");
                }
                finally
                {
                    Console.WriteLine("This cleanup code is always executed.");
                }
                Console.WriteLine("This code is after the try-finally block.");
            }

        }
    }
}
