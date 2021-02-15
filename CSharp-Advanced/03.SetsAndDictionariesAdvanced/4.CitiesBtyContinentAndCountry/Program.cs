using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.CitiesBtyContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> continents = new
               Dictionary<string, Dictionary<string, List<string>>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                var continent = input[0];
                var country = input[1];
                var city = input[2];
                if (!continents.ContainsKey(continent))
                {
                    continents.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!continents[continent].ContainsKey(country))
                {
                    continents[continent].Add(country, new List<string>());
                }
                continents[continent][country].Add(city);
            }
            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.Write($"  {country.Key} -> ");

                    Console.WriteLine(string.Join(", ",country.Value));
                }
            }
        }
    }
}


