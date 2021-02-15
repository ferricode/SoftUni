using System;

namespace IteratorsAndComparators
{
    class Program
    {
        static void Main(string[] args)
        {
            Book[] books = new Book[]
           {
            new Book("Winnie the Pooh", 1967,  "A.A.Milne"),
            new Book("Under the Yoke", 1895,  "Iv. Vazov" )
            };


            Library<Book> myLibrary = new Library<Book>(books);
           
            foreach (var item in myLibrary)
            {
                Console.WriteLine(item.Title);
            }
        }
    }
}
