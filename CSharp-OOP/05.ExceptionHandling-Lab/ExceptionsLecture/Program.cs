using System;

namespace ExceptionsLecture
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = null;

           
            ArgumentException ex = new ArgumentException("Neshto ne e v red");

            Console.WriteLine(ex.Message);
        }
    }
}
