﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int maxCapacity = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] cmdArg = command.Split();

                if (cmdArg[0] == "Add")
                {
                    wagons.Add(int.Parse(cmdArg[1]));
                }
                else
                {
                    int passengers = int.Parse(cmdArg[0]);
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        int currentWagon = wagons[i];
                        bool isEnughSpace = currentWagon + passengers <= maxCapacity;

                        if (isEnughSpace)
                        {
                            wagons[i] += passengers;
                            break;
                        }
                    }
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
