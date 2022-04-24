namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            Value = value;
            LeftChild = leftChild;
            if (this.LeftChild!=null)
            {
                this.LeftChild.Parent=this;
            }
            RightChild = rightChild;
            if (this.RightChild != null)
            {
                this.RightChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
           var firstNodeAncestors = this.GetAncestors(this.Search(first));
           var secondNodeAncestors = this.GetAncestors(this.Search(second));
            var intersection=firstNodeAncestors.Intersect(secondNodeAncestors);

            return intersection.ToArray()[0];
        }
        private List<T> GetAncestors(IAbstractBinaryTree<T> node)
        {
            var list = new List<T>();
            while (node!=null)
            {
                list.Add(node.Value);
                node = node.Parent;
            }
            return list;
        }
        public IAbstractBinaryTree<T> Search(T element)
        {

            var node = this;

            while (node != null)
            {

                if (isGreater(node.Value,element))
                {
                    node = node.LeftChild;
                }
                else if (isSmaller(node.Value,element))
                {
                    node = node.RightChild;

                }
                else
                {
                    return node;
                }
            }
            return null;
        }
        private bool isGreater(T value, T other)
        {
            return value.CompareTo(other) > 0;
        }
        private bool isSmaller(T value, T other)
        {
            return value.CompareTo(other) < 0;
        }
    }
}
