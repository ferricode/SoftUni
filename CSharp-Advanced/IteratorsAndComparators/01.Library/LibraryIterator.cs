using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class LibraryIterator<T> : IEnumerator<T>
    {
        private readonly List<T> books;

        private int currentIndex = -1;
        public LibraryIterator(List<T> books)
        {
            this.books = books;
        }

        public T Current => books[currentIndex];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
           
        }

        public bool MoveNext()
        {
            currentIndex++;
            return currentIndex < books.Count;
        }

        public void Reset()
        {
            currentIndex = -1;
        }
    }
}