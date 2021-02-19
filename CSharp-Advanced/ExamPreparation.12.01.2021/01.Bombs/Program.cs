using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {

            Queue<int> effects = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());

            Stack<int> casings = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());

            Dictionary<string, int> bombPounch = new Dictionary<string, int>();

            bombPounch.Add("Datura Bombs", 0);
            bombPounch.Add("Cherry Bombs", 0);
            bombPounch.Add("Smoke Decoy Bombs", 0);

            //Datura Bombs: 40
            //Cherry Bombs: 60
            //Smoke Decoy Bombs: 120
            //bool hasDatura = bombPounch["Datura Bombs"] >= 3;
            //bool hasCherry = bombPounch["Cherry Bombs"] >= 3;
            //bool hasDecoy = bombPounch["Smoke Decoy Bombs"] >= 3;

            //bool isFilledBombPunch = bombPounch["Datura Bombs"] >= 3 && bombPounch["Cherry Bombs"] >= 3 && bombPounch["Smoke Decoy Bombs"] >= 3;



            // bool hasMaterials = effects.Count > 0 && casings.Count > 0;

            while (effects.Count > 0 && casings.Count > 0)
            {
                

                int effect = effects.Peek();
                int casing = casings.Pop();
                int sum = effect + casing;

                if (sum == 40)
                {
                    bombPounch["Datura Bombs"]++;
                }
                else if (sum == 60)
                {
                    bombPounch["Cherry Bombs"]++;
                }
                else if (sum == 120)
                {
                    bombPounch["Smoke Decoy Bombs"]++;
                }
                else
                {
                    casings.Push(casing - 5);
                    continue;
                }
                effects.Dequeue();

                if (bombPounch["Datura Bombs"] >= 3 && bombPounch["Cherry Bombs"] >= 3 && bombPounch["Smoke Decoy Bombs"] >= 3)
                {
                    break;
                }
            }
            if (bombPounch["Datura Bombs"] >= 3 && bombPounch["Cherry Bombs"] >= 3 && bombPounch["Smoke Decoy Bombs"] >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (effects.Count != 0)
            {
                Console.WriteLine($"Bomb Effects: " + string.Join(", ", effects));
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            if (casings.Count != 0)
            {
                Console.WriteLine($"Bomb Casings: " + string.Join(", ", casings));
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach (var kvp in bombPounch.OrderBy(kvp => kvp.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

        }
    }
}
