using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Wordrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            //wardrobe.Add("blue", new Dictionary<string, int>());

            //Dictionary<string, int> wardrobeColorValue = wardrobe["blue"];
            //wardrobeColorValue.Add("dress", 1);
            //wardrobe["blue"].Add("dress", 1);

            for (int i = 0; i < n; i++)
            {
                string[] inputData = Console.ReadLine()
                    .Split(new[] {" -> ", "," }, StringSplitOptions.RemoveEmptyEntries);

                string color = inputData[0];
                string[] allClothing = inputData.Skip(1).ToArray();

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }
                Dictionary<string, int> currentColorClothing = wardrobe[color];

                foreach (string item in allClothing)
                {
                    if (!currentColorClothing.ContainsKey(item))
                    {
                        currentColorClothing.Add(item, 0);
                    }
                    currentColorClothing[item]++;
                }

            }

            string[] searchData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            //foreach (kvp<string, Dictionary<string, int>>colorData in wardrobe)
            foreach ((string color, Dictionary<string, int> colorData) in wardrobe)
            {
                Console.WriteLine($"{color} clothes:");

                foreach ((string clothing, int count) in colorData)
                {
                    if (searchData[0] == color && searchData[1] == clothing)
                    {
                        Console.WriteLine($"* {clothing} - {count} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothing} - {count}");
                    }
                  
                }
            }

        }
    }
}
