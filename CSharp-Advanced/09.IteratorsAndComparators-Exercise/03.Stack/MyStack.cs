using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03.Stack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private List<T> elements;

        public MyStack()
        {
            this.elements = new List<T>();
        }
        public MyStack(List<T> elements)
        {
            this.elements = elements;
        }
        public void Push(T element)
        {
            this.elements.Add(element);

        }
        public T Pop()
        {
            if (this.elements.Count==0)
            {
                throw new InvalidOperationException("No elements");
            }
            int index = this.elements.Count - 1;

            T element = this.elements[index];
            this.elements.RemoveAt(index);
            return element;

        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.elements.Count-1; i >= 0; i--)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
