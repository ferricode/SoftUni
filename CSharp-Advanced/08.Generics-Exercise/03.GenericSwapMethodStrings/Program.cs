﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GenericSwapMethodStrings
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            //List<Box<string>> boxes = new List<Box<string>>();
            List<Box<int>> boxes = new List<Box<int>>();

            for (int i = 0; i < n; i++)
            {
               // Box<string> box = new Box<string>(Console.ReadLine());
                Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));


                boxes.Add(box);
            }
            int[] indexes = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            SwapIndexes(boxes, indexes[0], indexes[1]);

            //foreach (Box<string> currentBox in boxes)
            //{
            //    Console.WriteLine(currentBox);
            //}
            foreach (Box<int> currentBox in boxes)
            {
                Console.WriteLine(currentBox);
            }
        }
            private static void SwapIndexes<T>(List<Box<T>> boxes, int firstIndex, int secondIndex)
            {
                Box<T> temp = boxes[firstIndex];
             
                boxes[firstIndex] = boxes[secondIndex];
                boxes[secondIndex] = temp;

            }
        }
    }

