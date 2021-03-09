using System;

namespace InnerException
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                try
                {
                    throw new StackOverflowException("Something bad happend");
                }
                catch (Exception ex)
                {

                    throw new ArgumentException("Somethin happend with your order");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }
        }
    }
}
