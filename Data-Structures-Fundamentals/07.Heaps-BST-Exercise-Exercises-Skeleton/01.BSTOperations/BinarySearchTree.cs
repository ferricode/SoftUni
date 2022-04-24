namespace _01.BSTOperations
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> root)
        {
            this.CopyNode(root);
        }

        private void CopyNode(Node<T> node)
        {
            if (node != null)
            {
                this.Insert(node.Value);
                this.CopyNode(node.LeftChild);
                this.CopyNode(node.RightChild);
            }
        }

        public Node<T> Root { get; private set; }

        public int Count { get; private set; }

        public bool Contains(T element)
        {

            var node = this.Root;

            while (node != null)
            {

                if (node.Value.CompareTo(element) > 0)
                {
                    node = node.LeftChild;
                }
                else if (node.Value.CompareTo(element) < 0)
                {
                    node = node.RightChild;

                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        private void Insert(T element, Node<T> node)
        {

            if (IsGreater(node.Value, element))
            {
                Insert(element, node.LeftChild);
            }
            else if (IsSmaller(node.Value, element))
            {
                Insert(element, node.RightChild);

            }

        }
        private bool IsGreater(T value, T other)
        {
            return value.CompareTo(other) > 0;
        }
        private bool IsSmaller(T value, T other)
        {
            return value.CompareTo(other) < 0;
        }

        public void Insert(T element)
        {

            var newNode = new Node<T>(element);
            if (this.Count == 0)
            {
                this.Root = newNode;
                this.Count++;
                return;
            }

            Node<T> parentNode = null;
            var node = this.Root;

            while (node != null)
            {

                parentNode = node;
                if (IsGreater(node.Value, element))
                {
                    node = node.LeftChild;
                }
                else if (IsSmaller(node.Value, element))
                {
                    node = node.RightChild;

                }
            }
            if (IsGreater(parentNode.Value, element))
            {
                parentNode.LeftChild = newNode;
            }
            else
            {
                parentNode.RightChild = newNode;
            }
            this.Count++;




        }
        public IAbstractBinarySearchTree<T> Search(T element)
        {

            var node = this.Root;

            while (node != null)
            {

                if (node.Value.CompareTo(element) > 0)
                {
                    node = node.LeftChild;
                }
                else if (node.Value.CompareTo(element) < 0)
                {
                    node = node.RightChild;

                }
                else
                {
                    return new BinarySearchTree<T>(node);
                }
            }
            return null;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(action, this.Root);
        }

        private void EachInOrder(Action<T> action, Node<T> node)
        {
            if (node == null)
            {
                return;
            }
            this.EachInOrder(action, node.LeftChild);
            action(node.Value);
            this.EachInOrder(action, node.RightChild);
        }

        public List<T> Range(T lower, T upper)
        {
            var list = new List<T>(0);
            this.Range(lower, upper, this.Root, list);
            return list;
        }

        private void Range(T startRange, T endRange, Node<T> node, List<T> result)
        {
            if (node == null)
            {
                return;
            }
            var InStartRange = (startRange.CompareTo(node.Value));
            var InEndRange = (startRange.CompareTo(node.Value));

            if (InStartRange < 0)
            {
                this.Range(startRange, endRange, node.LeftChild, result);
            }
            if (InStartRange <= 0 && InEndRange >= 0)
            {
                result.Add(node.Value);
            }
            if (InEndRange > 0)
            {
                this.Range(startRange, endRange, node.RightChild, result);
            }
        }

        public void DeleteMin()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            this.Root.LeftChild = this.DeleteMin(this.Root.LeftChild);
        }

        private Node<T> DeleteMin(Node<T> node)
        {
            if (node.LeftChild == null)
            {
                this.Count--;
                return node.RightChild;
            }
            node.LeftChild = this.DeleteMin(node.LeftChild);
            return node;
        }

        public void DeleteMax()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            this.Root.RightChild = this.DeleteMax(this.Root.RightChild);
        }

        private Node<T> DeleteMax(Node<T> node)
        {
            if (node.RightChild == null)
            {
                Count--;
                return node.LeftChild;
            }

            node.RightChild = this.DeleteMin(node.RightChild);
            return node;
        }
        public int GetRank(T element)
        {
            throw new NotImplementedException();
        }
    }
}
