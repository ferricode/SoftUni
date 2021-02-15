using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintNames("Pesho", "Gosho", "Misho");
        }
        private static void PrintNames(params string[] names)
        {
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
        }
    }
}
