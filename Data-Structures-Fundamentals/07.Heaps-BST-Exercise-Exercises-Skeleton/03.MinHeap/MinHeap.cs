namespace _03.MinHeap
{
    using System;
    using System.Collections.Generic;

    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> elements;

        public MinHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;

        public T Dequeue()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }
            T element = this.elements[0];
            Swap(0, this.Size - 1);
            this.elements.RemoveAt(this.elements.Count - 1);

            HeapifyDown(0);

            return element;


        }

        private void HeapifyDown(int parentIndex)
        {

            var smallerChildIndex = this.FindSmallerChild(parentIndex * 2 + 1, parentIndex * 2 + 2);

            while (smallerChildIndex != -1 && IsSmaller(smallerChildIndex, parentIndex))
            {
                Swap(smallerChildIndex, parentIndex);
                parentIndex = smallerChildIndex;
                smallerChildIndex = this.FindSmallerChild(parentIndex * 2 + 1, parentIndex * 2 + 2);
            }
        }

        private bool IsSmaller(int smallerChildIndex, int parentIndex)
        {
            return this.elements[smallerChildIndex].CompareTo(this.elements[parentIndex]) < 0;
        }

        private int FindSmallerChild(int leftChildIndex, int rightChildIndex)
        {
            if (leftChildIndex >= this.Size)
            {
                return -1;
            }

            if (rightChildIndex >= this.Size)
            {
                return leftChildIndex;
            }

            return leftChildIndex < rightChildIndex ? leftChildIndex : rightChildIndex;

        }

        public void Add(T element)
        {
            this.elements.Add(element);
            Heapify(this.Size - 1);
        }

        private void Heapify(int index)
        {
            if (index == 0) return;

            int parentIndex = (index - 1) / 2;
           while (IsSmaller(index, parentIndex))
            {
                Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = (index - 1) / 2;
               

            }
        }
        private void Swap(int index1, int index2)
        {
            T temp = this.elements[index1];
            this.elements[index1] = this.elements[index2];
            this.elements[index2] = temp;
        }
        public T Peek()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }
            return this.elements[0];
        }
    }
}
