using System;

namespace _05.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int numberOfProducts = int.Parse(Console.ReadLine());

            TotalPrice(product, numberOfProducts);
        }

        private static void TotalPrice(string product, int numberOfProducts)
        {
            double price = 0.0;

            switch (product)
            {
                case "coffee":
                    price = 1.5 * numberOfProducts;
                    break;
                case "water":
                    price = 1.0 * numberOfProducts;
                    break;
                case "coke":
                    price = 1.4 * numberOfProducts;
                    break;
                case "snacks":
                    price = 2.0 * numberOfProducts;
                    break;
            };
            Console.WriteLine($"{price:f2}");
        }
    }
}
