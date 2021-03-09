using System;

namespace CustomExceptions
{
    class Program
    {
        static void Main(string[] args)
        {

            Account account = new Account();

            while (true)
            {
                Console.WriteLine("Enter new order amount");
                decimal amount = decimal.Parse(Console.ReadLine());

                try
                {
                    account.PlaceOrder(amount);
                }

                catch (OrderException ex)
                {

                    Console.WriteLine($"Order was not placed { ex.InnerException.Message}");
                }
            }
        }
    }
}
