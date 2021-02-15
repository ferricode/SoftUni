using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pumpsCount = int.Parse(Console.ReadLine());
            Queue<string> pumpsData = new Queue<string>();

            for (int i = 0; i < pumpsCount; i++)
            {
                pumpsData.Enqueue(Console.ReadLine());
            }


            for (int i = 0; i < pumpsCount; i++)
            {
                int currPetrolAmount = 0;
                bool isSuccessfull = true;

                for (int j = 0; j < pumpsCount; j++)
                {
                    int[] pumpData = pumpsData.Dequeue().Split(" ").Select(int.Parse).ToArray();
                    pumpsData.Enqueue(string.Join(" ", pumpData));

                    currPetrolAmount += pumpData[0];

                    currPetrolAmount -= pumpData[1];

                    if (currPetrolAmount < 0)
                    {
                        isSuccessfull = false;
                        continue;
                    }

                }
                if (isSuccessfull)
                {
                    Console.WriteLine(i);
                    break;
                }
                string tempData = pumpsData.Dequeue();
                pumpsData.Enqueue(tempData);
            }
        }
    }
}
