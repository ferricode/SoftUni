using System;

namespace ThrowingExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstLevelCall();
        }
        static void FirstLevelCall()
        {
            SecondLevelCall();
        }

        private static void SecondLevelCall()
        {
            try
            {
                ThirdLevelCall();
            }
            catch (Exception)
            {
                Console.WriteLine("Stop the boom");
            }
           
        }

        private static void ThirdLevelCall()
        {
            throw new ArgumentException("Test");
        }
    }
}
