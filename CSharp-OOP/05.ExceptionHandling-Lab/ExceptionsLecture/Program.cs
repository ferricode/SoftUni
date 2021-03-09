using System;

namespace ExceptionsLecture
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = 0;

            try
            {
                Console.WriteLine("Kolko si dyrt");
                age = int.Parse(Console.ReadLine());

                if (age<20)
                {
                    throw new ArgumentException("Nasha si greshka");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType().ToString());
                Console.WriteLine("Tolkova li ne mojesh da vavedesh edno chislo????");

                age = int.Parse(Console.ReadLine());
            }


            Console.WriteLine($"{age} - abe dyrt si...");
        }
    }
}
