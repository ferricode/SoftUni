using System;
using System.Collections.Generic;

namespace _04.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> input = new Dictionary<string, List<double>>();

            string command = Console.ReadLine();

            while (command != "buy")
            {

                string[] currentProduct = command.Split();
                string productName = currentProduct[0];
                double productPrice = double.Parse(currentProduct[1]);
                double productQuantity = double.Parse(currentProduct[2]);
                if (!input.ContainsKey(productName))
                {
                    List<double> priceAndQuantity = new List<double> { productPrice, productQuantity };
                    input.Add(productName, priceAndQuantity);
                }
                else
                {
                    input[productName][0] = productPrice;//взима нулевият елемент от листа на дикт. и му присвоява productPrıca.
                    input[productName][1] = input[productName][1] + productQuantity;
                }

                command = Console.ReadLine();

            }
            foreach (var item in input)
            {
                double totalPrice = item.Value[0] * item.Value[1];
                Console.WriteLine($"{item.Key} -> {totalPrice:f2}");
            }
        }
    }
}
