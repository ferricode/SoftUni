using System;
using System.Collections.Generic;

namespace Heap
{
    class Program
    {
        static void Main(string[] args)
        {
            var integerHeap = new Heap<int>();
            var elements = new List<int>() { 15, 6, 9, 5, 25, 8, 17, 16 };
            foreach (var el in elements)
            {
                integerHeap.Add(el);
            }
            Console.WriteLine(integerHeap.DFSInOrder(0,0));
        }
    }
}
