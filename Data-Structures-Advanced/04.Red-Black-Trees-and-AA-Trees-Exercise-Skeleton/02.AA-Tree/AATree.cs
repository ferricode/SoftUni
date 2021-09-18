namespace _02._AA_Tree
{
    using System;

    public class AATree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private Node<T> root;
        public int CountNodes()
        {
            return this.CountNodes(this.root);
        }

        private int CountNodes(Node<T> root)
        {
            if (root == null)
            {
                return 0;
            }
            return 1 + CountNodes(root.Left) + CountNodes(root.Right);
        }

        public bool IsEmpty()
        {
            return this.root == null;
        }

        public void Clear()
        {
            this.root = null;
        }

        public void Insert(T element)
        {
            this.root = Insert(element, this.root);
        }

        private Node<T> Insert(T element, Node<T> node)
        {
            if (node == null)
            {
                node = new Node<T>(element);
            }
            else if (element.CompareTo(node.Element) < 0)
            {
                node.Left = Insert(element, node.Left);
            }
            else
            {
                node.Right = Insert(element, node.Right);
            }

            node = this.Skew(node);
            node = this.Split(node);
            return node;
        }

        private Node<T> Split(Node<T> node)
        {
            if (node.Right == null || node.Right.Right == null)
            {
                return node;
            }
            else if (node.Right.Right.Level == node.Level)
            {
                node = Promote(node);
            }
            return node;
        }

        private Node<T> Promote(Node<T> node)
        {
            var newNode = node.Right;
            node.Right = newNode.Left;
            newNode.Left = node;
            newNode.Level++;

            return newNode;

        }

        private Node<T> Skew(Node<T> node)
        {
            if (node.Left != null && node.Left.Level == node.Level)
            {
                node = RotateLeft(node);
            }
            return node;
        }

        private Node<T> RotateLeft(Node<T> node)
        {
            var newNode = node.Left;
            node.Left = newNode.Right;
            newNode.Right = node;

            return newNode;
        }
        public bool Search(T element)
        {
            if (Search(element, root) != null)
            {
                return true;
            }
            return false;
        }

        private Node<T> Search(T element, Node<T> node)
        {
            // var node = this.root;

            while (node != null)
            {

                if (node.Element.CompareTo(element) > 0)
                {
                    node = Search(element, node.Left);
                }
                else if (node.Element.CompareTo(element) < 0)
                {
                    node = Search(element, node.Right);

                }
                else
                {
                    return node;
                }
            }
            return null;
        }

        public void InOrder(Action<T> action)
        {
            this.InOrder(action, this.root);
        }

        private void InOrder(Action<T> action, Node<T> node)
        {
            if (node == null)
            {
                return;
            }
            this.InOrder(action, node.Left);
            action(node.Element);
            this.InOrder(action, node.Right);
        }


        public void PreOrder(Action<T> action)
        {
            PreOrder(action, this.root);
        }

        private void PreOrder(Action<T> action, Node<T> node)
        {

            if (node == null)
            {
                return;
            }
            action(node.Element);
            this.PreOrder(action, node.Left);
            this.PreOrder(action, node.Right);


        }

        public void PostOrder(Action<T> action)
        {

            PostOrder(action, this.root);
        }

        private void PostOrder(Action<T> action, Node<T> node)
        {

            if (node == null)
            {
                return;
            }
            this.PostOrder(action, node.Left);
            this.PostOrder(action, node.Right);
            action(node.Element);


        }
    }
}