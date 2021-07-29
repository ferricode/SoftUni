namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.items[this.Count - index - 1];
            }
            set
            {
                this.ValidateIndex(index);
                this.items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (this.Count == this.items.Length)
            {
                this.items = this.Grow(this.items, this.Count);
            }
            this.items[this.Count++] = item;
        }

        public bool Contains(T item)
        {

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (this.items[i].Equals(item))
                {
                    return this.Count - i - 1;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);

            if (this.Count == this.items.Length)
            {
                this.items = this.Grow(this.items, this.Count);
            }
            for (int i = this.Count; i >= this.Count - index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
            this.items[this.Count - index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Equals(item))
                {
                    T[] newItems = new T[Count - 1];
                    
                    for (int m = 0; m < i; m++)
                    {
                        newItems[m] = items[m];
                    }
                    for (int k = i; k < Count - 1; k++)
                    {
                        newItems[k] = this.items[k + 1];
                    }
                    items = newItems;
                    this.Count--;
                    return true;
                }
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);
            int myIndex = Count - index - 1;
            T[] newItems = new T[Count - 1];

            for (int m = 0; m < myIndex; m++)
            {
                newItems[m] = items[m];
            }
            for (int k = myIndex; k < Count - 1; k++)
            {
                newItems[k] = this.items[k + 1];
            }
            items = newItems;
            this.Count--;
         
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i > 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }
        private T[] Grow(T[] currentItems, int itemCount)
        {
            var tempArray = new T[currentItems.Length * 2];
            Array.Copy(currentItems, tempArray, itemCount);
            return tempArray;
        }
    }
}