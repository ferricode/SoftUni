using System;

namespace InnerException
{
    class Program
    {
        static void Main(string[] args)
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
    }
}
