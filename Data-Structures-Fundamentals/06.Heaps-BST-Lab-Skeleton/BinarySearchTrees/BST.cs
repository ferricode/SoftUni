using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTrees
{
    public class BST<T> where T:IComparable<T>
    {
        public BST(Node<T> root=null)
        {
            Root = root;
        }

        public Node<T> Root { get; set; }

        //check if value is bigger or smaller than root
        //go left or right accordingly
        //repeat for child element
        //find the first null child element and put the new node there
        public void Insert(T value, Node<T> node)
        {
            if (node==null)
            {
                node = new Node<T>(value);
                Root = node;
                return;
            }
            if (node.Value.CompareTo(value) > 0)
            {
                if (node.LeftChild==null)
                {
                    node.LeftChild = new Node<T>(value);
                    return;
                }
                Insert(value, node.LeftChild);
            }
            else
            {
                if (node.RightChild==null)
                {
                    node.RightChild = new Node<T>(value);
                    return;
                }
                Insert(value, node.RightChild);
            }
        }
        public string DFSInOrder(Node<T> node, int indent)
        {
            string result = "";

            if (node.LeftChild != null)
            {
                result += DFSInOrder(node.LeftChild, indent + 3);
            }

            result += $"{new string(' ', indent)}{node.Value}\n";

            if (node.RightChild != null)
            {
                result += DFSInOrder(node.RightChild, indent + 3);
            }

            return result;
        }
        public bool Contains(T value, Node<T> node)
        {
            if (node==null)
            {
                return false;
            }
            if (node.Value.CompareTo(value) == 0)
            {

                return true;
            }
            if (node.Value.CompareTo(value) > 0)
            { 
            
             return Contains(value, node.LeftChild);
            }
            else
            {
             return Contains(value, node.RightChild);
            }
        }
    }
}
