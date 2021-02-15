using System;
using System.Collections.Generic;

namespace _5.GenericCountMethodStrings
{
    public class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            List<Box<double>> boxes = new List<Box<double>>();

            for (int i = 0; i < n; i++)
            {
                Box<double> box = new Box<double>(double.Parse(Console.ReadLine()));
                //Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));
                boxes.Add(box);
            }

            double value = double.Parse(Console.ReadLine());
            Box<double> comparableBox = new Box<double>(value);
            int count = GetGreaterThanCoun(boxes, comparableBox);
            Console.WriteLine(count);

        }
        private static int GetGreaterThanCoun<T>(List<Box<T>> boxes, Box<T> box)
            where T : IComparable
        {
            int count = 0;
            foreach (Box<T> currentBox in boxes)
            {
                //int compare = currentBox.Value.CompareTo(box.Value);
                int compare = currentBox.CompareTo(box);
                if (compare > 0)
                {
                    count++;
                }

            }
            return count;
        }



    }

}
