using System;

namespace TryCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = 0;
            try
            {
                Console.WriteLine("Na kolko godini si");
                age = int.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {

                Console.WriteLine("Tolkova li ne moje6 bda vavede6 edno 4islo????");

                age = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"{age} abe dyrt si");

        }
    }
}
