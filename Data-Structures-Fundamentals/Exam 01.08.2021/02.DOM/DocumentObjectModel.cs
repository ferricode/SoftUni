namespace _02.DOM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _02.DOM.Interfaces;
    using _02.DOM.Models;

    public class DocumentObjectModel : IDocument
    {
        private PriorityQueue<IHtmlElement> queue;
        public DocumentObjectModel()
        {
            this.queue = new PriorityQueue<IHtmlElement>();


        }
        public DocumentObjectModel(IHtmlElement root)
        {
            this.Root = root;
            this.queue = new PriorityQueue<IHtmlElement>();
        }

        public DocumentObjectModel(PriorityQueue<IHtmlElement> queue)
        {
            this.queue = queue;
            this.Root = queue.Peek();

        }

        public IHtmlElement Root { get; private set; }

        public IHtmlElement GetElementByType(ElementType type)
        {
            List<IHtmlElement> getElementList = BFS(this.Root);
            var elementToReturn = getElementList.FirstOrDefault(x => x.Type == type);
            return elementToReturn;
        }

        public List<IHtmlElement> GetElementsByType(ElementType type)
        {
            return DFS(Root, 0);
        }

        public bool Contains(IHtmlElement htmlElement)
        {
            throw new NotImplementedException();
        }

        public void InsertFirst(IHtmlElement parent, IHtmlElement child)
        {
            throw new NotImplementedException();
        }

        public void InsertLast(IHtmlElement parent, IHtmlElement child)
        {
            throw new NotImplementedException();
        }

        public void Remove(IHtmlElement htmlElement)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll(ElementType elementType)
        {
            throw new NotImplementedException();
        }

        public bool AddAttribute(string attrKey, string attrValue, IHtmlElement htmlElement)
        {
            throw new NotImplementedException();
        }

        public bool RemoveAttribute(string attrKey, IHtmlElement htmlElement)
        {
            throw new NotImplementedException();
        }

        public IHtmlElement GetElementById(string idValue)
        {
            throw new NotImplementedException();
        }
        public List<IHtmlElement> BFS(IHtmlElement root)
        {
            //Add root to quee
            //while queue not empty
            //queue dequeue
            //foreach child in current node enqueue
            List<IHtmlElement> list = new List<IHtmlElement>();
            Queue<IHtmlElement> queue = new Queue<IHtmlElement>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                IHtmlElement node = queue.Dequeue();
                list.Add(node);

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }

            }
            return list;
        }
        public List<IHtmlElement> DFS(IHtmlElement root, int level)
        {


            List<IHtmlElement> list = new List<IHtmlElement>();

            // list.Add(node.Value);

            foreach (var child in root.Children)
            {
                list.AddRange(DFS(child, level + 1));
            }

            list.Add(root);

            return list;
        }
    }
}
