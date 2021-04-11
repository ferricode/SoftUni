using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int wavesNumber = int.Parse(Console.ReadLine());
            Queue<int> plates = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Stack<int> orcs = new Stack<int>();

            bool isOrcsEnd = false;
            bool isPlatesEnd = false;

            int counter = 1;

            while (counter <= wavesNumber)
            {
                orcs = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());

                if (counter % 3 == 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    plates.Enqueue(newPlate);
                    isPlatesEnd = false;
                }

                while (orcs.Count > 0)
                {
                    int currOrc = orcs.Pop();
                    int currPlate = plates.Dequeue();
                    List<int> platesList = new List<int>(plates);

                    if (currOrc > currPlate)
                    {
                        currOrc -= currPlate;
                        orcs.Push(currOrc);
                    }
                    else if (currOrc < currPlate)
                    {
                        currPlate -= currOrc;
                        if (currPlate > 0)
                        {
                            platesList.Insert(0, currPlate);
                            plates = new Queue<int>(platesList);
                        }

                    }

                    if (plates.Count == 0)
                    {
                        isPlatesEnd = true;
                        break;
                    }

                }
                if (plates.Count == 0)
                {
                    isPlatesEnd = true;
                    break;
                }
                counter++;

           
            }
            if (counter > wavesNumber && orcs.Count == 0)
            {
                isOrcsEnd = true;
            }

            if (isPlatesEnd)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: " + string.Join(", ", orcs));
            }
            if (isOrcsEnd)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: " + string.Join(", ", plates));
            }
        }
    }
}
