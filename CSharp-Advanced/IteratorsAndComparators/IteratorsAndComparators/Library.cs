using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library:IEnumerable<Book>
    {
        public Library()
        {
            Books = new List<Book>();
        }
        public List<Book> Books { get; private set; }

        public void Add(Book book)
        {
            Books.Add(book);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryEnumerator(this.Books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class LibraryEnumerator : IEnumerator<Book>
    {
        private int currentIndex=-1;

        private readonly List<Book> books;

        public LibraryEnumerator(List<Book> books)
        {
            this.books = books;
        }

        public Book Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            this.currentIndex++;
            if (currentIndex>=books.Count)
            {
                return false;
            }
            return true;
        }

        public void Reset()
        {
            currentIndex=-1;
        }
    }
}
