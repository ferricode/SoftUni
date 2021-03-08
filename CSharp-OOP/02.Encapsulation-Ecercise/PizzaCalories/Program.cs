using System;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            // System.Globalization.CultureInfo invariantCulture =
            // System.Globalization.CultureInfo.InvariantCulture;


            var pizzaName = Console.ReadLine().Split()[1];
            string[] doughArgs = Console.ReadLine().Split();
            string flourType = doughArgs[1];
            string bakingTechnique = doughArgs[2];
            int weight = int.Parse(doughArgs[3]);

            try
            {
                var dough = new Dough(flourType, bakingTechnique, weight);
                var pizza = new Pizza(pizzaName, dough);

                while (true)
                {
                    var line = Console.ReadLine();
                    if (line.ToLower() == "end")
                    {
                        break;
                    }

                    var parts = line.Split();

                    string toppingName = parts[1];
                    int toppingWeight = int.Parse(parts[2]);

                    Topping topping = new Topping(toppingName, toppingWeight);

                    pizza.AddTopping(topping);
                }

                Console.WriteLine($"{pizzaName} - {pizza.GetCalories():f2} Calories.");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}