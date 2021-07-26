﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Hashset
{
    class Program
    {
        static void Main(string[] args)
        {
            //Array student names
            //Write a function that acsepts student names and returns true/false
            //weather students is in the array
            int count = 100000;
            int[] array = new int[count];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }

            Stopwatch watch = new Stopwatch();

            watch.Start();
            bool isThere = false;
            for (int i = 0; i < count; i++)
            {
                isThere = LinearFind(array, -5);
            }

            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            watch.Reset();
            HashSet<int> set = new HashSet<int>(array);
            watch.Start();
            for (int i = 0; i < count; i++)
            {
                isThere = ConstantTimeFind(set, -5);
            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
        }
        //O(1)
        static bool ConstantTimeFind(HashSet<int> array, int element)
        {
            return array.Contains(element);
        }

        //O(n)
        static bool LinearFind(int[] array, int element)
        {
            return array.Contains(element);

            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (array[i] == element)
            //    {
            //        return true;
            //    }

            //}
            //return false;
        }


    }
}
