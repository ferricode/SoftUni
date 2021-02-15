using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Dictionary<string, int> cookedProducts = new Dictionary<string, int>();

            //Bread   25
            //Cake    50
            //Pastry  75
            //Fruit Pie   100

            cookedProducts.Add("Bread", 0);
            cookedProducts.Add("Cake", 0);
            cookedProducts.Add("Fruit Pie", 0);
            cookedProducts.Add("Pastry", 0);

            while (liquids.Count > 0 && ingredients.Count > 0)
            {

                int liquid = liquids.Dequeue();
                int ingredient = ingredients.Pop();
                int sum = liquid + ingredient;

                switch (sum)
                {
                    case 25:
                        cookedProducts["Bread"]++;
                        break;
                    case 50:
                        cookedProducts["Cake"]++;
                        break;
                    case 100:
                        cookedProducts["Fruit Pie"]++;
                        break;
                    case 75:
                        cookedProducts["Pastry"]++;
                        break;
                    default:
                        ingredients.Push(ingredient + 3);
                        break;

                }
            }
            if (!cookedProducts.ContainsValue(0))
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count != 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredients.Count != 0)
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");

            }

            foreach (var kvp in cookedProducts.OrderBy(k => k.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
