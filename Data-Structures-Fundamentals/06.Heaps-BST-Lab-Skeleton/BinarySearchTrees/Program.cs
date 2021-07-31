using System;
using System.Collections.Generic;

namespace BinarySearchTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 100; i+=2)
            {
                list.Add(i);
            }

            BST<int> tree = new BST<int>();
            //for (int i = list.Count/2; i>=0; i--)
            //{
            //    tree.Insert(list[i], tree.Root);
            //}
            //for (int i = list.Count / 2+1; i <list.Count; i++)
            //{
            //    tree.Insert(list[i], tree.Root);
            //}

            Insert(tree, 0, list.Count, list);

            Console.WriteLine($"Find 57-> {tree.Contains(57, tree.Root)}");
            Console.WriteLine($"Find 22-> {tree.Contains(0, tree.Root)}");
            Console.WriteLine( tree.DFSInOrder(tree.Root, 0));
        }

        private static void Insert(BST<int> tree, int start, int end, List<int> list)
        {
            if (start>=end)
            {
                return;
            }
            var middle = (start + end) / 2;
            tree.Insert(list[middle], tree.Root);
            Insert(tree, start, middle-1, list);
            Insert(tree, middle+1, end, list);
        }
    }
}
