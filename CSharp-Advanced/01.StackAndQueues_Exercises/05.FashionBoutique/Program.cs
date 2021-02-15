using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothesInput = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Stack<int> allClothes = new Stack<int>(clothesInput);

            int boxCapacity = int.Parse(Console.ReadLine());

            int currentRackCapacity = boxCapacity;
            int racksCount = 1;

            while (allClothes.Any())
            {
                int chlotes = allClothes.Pop();

                currentRackCapacity -= chlotes;

                if (currentRackCapacity<0)
                {
                    racksCount++;
                    currentRackCapacity = boxCapacity - chlotes;
                }
            }
            Console.WriteLine(racksCount);
        }
    }
}
