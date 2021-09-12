namespace _01.Hierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;

    public class Hierarchy<T> : IHierarchy<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public List<Node> Children { get; set; }
            public Node(T value)
            {
                this.Value = value;
                this.Children = new List<Node>();
            }
        }
        private Node root;
        private Dictionary<T, Node> parentsByChildValue;
        private Dictionary<T, Node> nodesByValue;

        public Hierarchy(T value)
        {
            this.parentsByChildValue = new Dictionary<T, Node>();
            this.nodesByValue = new Dictionary<T, Node>();
            this.root = new Node(value);
            this.nodesByValue.Add(value, this.root);
            this.parentsByChildValue.Add(value, null);
        }

        public int Count 
        {
            get
            {
                return this.nodesByValue.Count;
            }
        }
        

        public void Add(T parentValue, T childValue)
        {
            if (!nodesByValue.ContainsKey(parentValue)||nodesByValue.ContainsKey(childValue))
            {
                throw new ArgumentException();
            }
            var childNode = new Node(childValue);
            this.nodesByValue.Add(childValue, childNode);
            this.parentsByChildValue.Add(childValue, this.nodesByValue[parentValue]);
            this.nodesByValue[parentValue].Children.Add(childNode);
        }

        public void Remove(T element)
        {
            if (element.Equals(this.root.Value))
            {
                throw new InvalidOperationException();
            }
            else if (!this.nodesByValue.ContainsKey(element))
            {
                throw new ArgumentException();
            }

            var parentNode = this.parentsByChildValue[element];
            var node = this.nodesByValue[element];
            
            parentNode.Children.Remove(node);
            parentNode.Children.AddRange(node.Children);

            foreach (var child in node.Children)
            {
                this.parentsByChildValue[child.Value] = parentNode;

            }
            this.nodesByValue.Remove(element);
            this.parentsByChildValue.Remove(element);

        }

        public IEnumerable<T> GetChildren(T element)
        {
            if (!this.nodesByValue.ContainsKey(element))
            {
                throw new ArgumentException();
            }
            return nodesByValue[element].Children.Select(node => node.Value);
        }

        public T GetParent(T element)
        {
            if (!this.nodesByValue.ContainsKey(element))
            {
                throw new ArgumentException();
            }
            var parentNode = this.parentsByChildValue[element];
            return parentNode!=null?parentNode.Value:default;
        }

        public bool Contains(T element)
        {
          
            return this.nodesByValue.ContainsKey(element);
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            var keys = new List<T>();
            foreach (var key in this.nodesByValue.Keys)
            {
                if (other.nodesByValue.ContainsKey(key))
                {
                    keys.Add(key);
                }
            }

            return keys;

            //return this.nodesByValue.Keys.Intersect(other.nodesByValue.Keys);
        }

        public IEnumerator<T> GetEnumerator()
        {
            var queue = new Queue<Node>();
            queue.Enqueue(this.root);

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                yield return node.Value;

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }

            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}