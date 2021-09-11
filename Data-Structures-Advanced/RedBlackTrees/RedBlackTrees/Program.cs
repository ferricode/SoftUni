using System;

namespace RedBlackTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.BackgroundColor = ConsoleColor.White;


            RBTree tree = new RBTree();
            for (int i = 1; i <= 8; i++)
            {
                tree.Insert(9-i);
                tree.DFS();
                Console.BackgroundColor = ConsoleColor.White;

            }

            //Left Rotation
            //tree.Insert(1);
            //tree.Insert(5);
            //tree.Insert(9);
            //tree.Insert(4);
            //tree.Insert(6);
            //tree.Insert(11);
            //tree.Insert(0);
            //var node = TreeRotations.LeftRotation(tree.Root);


            //Right Rotation
            //tree.Insert(8);
            //tree.Insert(4);
            //tree.Insert(1);
            // var node = TreeRotations.RightRotation(tree.Root);

            ////RightLeft Rotation
            //tree.Insert(2);
            //tree.Insert(0);
            //tree.Insert(1);
            //tree.Insert(-1);
            //tree.Insert(5);
            //tree.Insert(4);

            //var node = TreeRotations.RightLeftRotation(tree.Root);

            //LeftRight Rotation ...


            // tree.DFS();
            Console.BackgroundColor = ConsoleColor.White;
        }
    }
}
