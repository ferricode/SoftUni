namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this.children = new List<Tree<T>>();

            foreach (var child in children)
            {
                this.AddChild(child);
                child.AddParent(this);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {
            return this.GetAsString(0).Trim();
        }

        private string GetAsString(int identation = 0)
        {
            var result = new string(' ', identation) + this.Key + "\r\n";
            foreach (var child in this.Children)
            {
                result += child.GetAsString(identation + 2);
            }
            return result;
        }
        public Tree<T> GetDeepestLeftomostNode()
        {
            throw new NotImplementedException();
        }

        public List<T> GetLeafKeys()
        {

            var leafNodes = this.GetLeafNodes();
            return leafNodes.Select(x => x.Key).ToList();
        }
        private List<Tree<T>> GetLeafNodes()
        {
            var leafNodes = new List<Tree<T>>();
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count >= 1)
            {
                var node = queue.Dequeue();

                if (node.Children.Count == 0)
                {
                    leafNodes.Add(node);
                }
                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return leafNodes;
        }
        public List<T> GetMiddleKeys()
        {
            var middleNodes = this.GetMiddleNodes();
            return middleNodes.Select(x => x.Key).ToList();
        }

        private List<Tree<T>> GetMiddleNodes()
        {
            var middleNodes = new List<Tree<T>>();
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count >= 1)
            {
                var node = queue.Dequeue();

                if (node.Children.Count != 0 && node.Parent != null)
                {
                    middleNodes.Add(node);
                }
                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }
            return middleNodes;
        }
        public List<T> GetLongestPath()
        {
            throw new NotImplementedException();
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {

            var list = new List<List<T>>();
            var currentSum = 0;
            this.PathsWithGivenSumDFS(this, ref currentSum, sum, list, new List<T>());
            return list;
            //var leafNodes = this.GetLeafNodes();
            //var result = new List<List<T>>();

            //foreach (var leaf in leafNodes)
            //{
            //    var node = leaf;
            //    var currentSum = 0;

            //    var currentNodes = new List<T>();

            //    while (node!=null)
            //    {
            //        currentNodes.Add(node.Key);
            //        currentSum +=Convert.ToInt32(node.Key); //int.Parse(node.Key.ToString())
            //        node = node.Parent;
            //    }
            //    if (currentSum==sum)
            //    {
            //        currentNodes.Reverse();
            //        result.Add(currentNodes);
            //    }
            //}
            //return result;
        }
        private void PathsWithGivenSumDFS(
            Tree<T> node,
            ref int currentSum,
            int targetSum,
            List<List<T>> allPaths,
            List<T> currentPathValues)
        {
            currentSum += Convert.ToInt32(node.Key);
            currentPathValues.Add(node.Key);
            
            foreach (var child in node.Children)
            {
                this.PathsWithGivenSumDFS(child, ref currentSum, targetSum, allPaths, currentPathValues);

                if (currentSum == targetSum)
                {
                    allPaths.Add(new List<T>(currentPathValues));
                }
                currentSum -= Convert.ToInt32(child.Key);
                currentPathValues.RemoveAt(currentPathValues.Count - 1);

            }


        }
        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            var roots = new List<Tree<T>>();

            SubTreeSumDfs(this, sum, roots);

            return roots;
        }
        private int SubTreeSumDfs(Tree<T>node, int targetSum, List<Tree<T>> roots)
        {
            var currentSum = Convert.ToInt32(node.Key);


            foreach (var child in node.Children)
            {
                currentSum+=SubTreeSumDfs(child, targetSum, roots);
            }
            if (currentSum==targetSum)
            {
                roots.Add(node);
            }
            return currentSum;
        }
    }
}
