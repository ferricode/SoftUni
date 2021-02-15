using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library<T> : IEnumerable<T> where T:IComparable<T>
    {
        private readonly SortedList books;
        public Library(IEnumerable<T> books)
        {
            this.books = new List<T>(books);
        }
        public Library()
        {
            BookComparer comparer = new BookComparer();
            books = new SortedList(comparer);
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var book in books)
            {
                yield return book;
            }
            //02.return new LibraryIterator<T>(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }
}
