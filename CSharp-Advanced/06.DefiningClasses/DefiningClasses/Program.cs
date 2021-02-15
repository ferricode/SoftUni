using System;

namespace DefiningClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Bear gogi = new Bear();
            gogi.Age = 28;
            gogi.DaysSinceEaten = 5;
            gogi.Name = "Gogi";

            Bear dimitrichko = new Bear();
            dimitrichko.Age = 28;
            dimitrichko.DaysSinceEaten = 2;
            dimitrichko.Name = "Dimitrichko";

            Bear pouhBear = new Bear();
            pouhBear.Age = 25;
            pouhBear.DaysSinceEaten = 3;
            pouhBear.Name = "Mecho Puh";

            Bear[] bearZoo = new Bear[] { gogi, dimitrichko, pouhBear };

            foreach (Bear bear in bearZoo)
            {
                if (bear.DaysSinceEaten>=3)
                {
                    bear.Eat();
                }
            }

            int number = 5;
            Shirt calvinKlein = new Shirt();
            calvinKlein.size = "XXS";
            calvinKlein.quantity = 55;
            calvinKlein.price = 3;
            Console.WriteLine($"Teniska callvin:{calvinKlein.size}, Quantity:{calvinKlein.quantity}, Price: {calvinKlein.price}");
        }
    }
}
