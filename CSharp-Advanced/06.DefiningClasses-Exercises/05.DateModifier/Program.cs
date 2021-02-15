using System;

namespace _05.DateModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            int days = DateModifier.GetDiffBetweenDatesInDays(firstDate, secondDate);
            Console.WriteLine(days);
        }
    }
}
