using System;

namespace ExceptionPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //get all users from database
            }
            catch (Exception ex)
            {
                //logger.Log(ex);
                throw    ex;
            }
        }
    }
}
