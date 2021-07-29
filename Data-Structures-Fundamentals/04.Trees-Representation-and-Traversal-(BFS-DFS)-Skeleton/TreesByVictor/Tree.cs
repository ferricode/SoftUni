using System;
using System.Collections.Generic;
using System.Text;

namespace TreesByVictor
{
    public class Tree<T>
    {
        //https://clementmihailescu.github.io/Pathfinding-Visualizer/#
        public Node<T> Root { get; set; }

        //public void DFS(Node<T> node, int level)
        //{
        //    Console.Write(new string(' ', level));
        //    Console.WriteLine(node);

        //    foreach (var child in node.Children)
        //    {
        //        DFS(child, level + 3);
        //    }
        //}

        public List<T> DFS(Node<T> node, int level)
        {


            List<T> list = new List<T>();

           // list.Add(node.Value);

            foreach (var child in node.Children)
            {
               list.AddRange(DFS(child, level + 3));
            }

            list.Add(node.Value);

            return list;
        }
        public List<Node<T>> BFS(Node<T> root)
        {
            //Add root to quee
            //while queue not empty
            //queue dequeue
            //foreach child in current node enqueue
            List<Node<T>> list = new List<Node<T>>();
            Queue<Node<T>> queue = new Queue<Node<T>>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node<T> node = queue.Dequeue();
                list.Add(node);

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }

            }
            return list;

        }
    }
}
