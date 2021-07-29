using System;
using System.Collections.Generic;

namespace TreesByVictor
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> root = new Node<int>(7,
                new Node<int>(19,
                    new Node<int>  (1),
                    new Node<int>  (12),
                    new Node<int>  (31)),
                new Node<int>(21),
                new Node<int>(14,
                    new Node<int>(23),  
                    new Node<int>(6))
                );

            Tree<int> tree = new Tree<int>();
            tree.Root = root;
           // List<Node<int>> treeAsList = tree.BFS(root);

            //Console.WriteLine(String.Join(", ", treeAsList));

            //tree.DFS(root, 0);

            Console.WriteLine(String.Join(", ", tree.DFS(root, 0)));
            //Node<int> node1 = new Node<int>(1);
            //Node<int> node2 = new Node<int>(2);
            //Node<int> node3 = new Node<int>(3);
            //Node<int> node4 = new Node<int>(4);

            //node1.Children.Add(node2);
            //node1.Children.Add(node3);

            //node2.Children.Add(node4);
        }
    }
}
