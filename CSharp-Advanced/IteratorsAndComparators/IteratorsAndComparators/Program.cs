using System;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    class Program
    {
        static void Main(string[] args)
        {
            var library = new Library();
            library.Add(new Book("1984", 1980, new List<string> { "Jeorge Orwell" }));
            library.Add(new Book("The Godfather", 1981, new List<string> { "Mario Puzo" }));
            library.Add(new Book("TLOTR", 1954, new List<string> { "J.Tolkin" }));

            foreach (var book in library)
            {
                Console.WriteLine($"{string.Join(book.Authors)} - {book.Title} ({book.Year})");
            }

        }
    }
}
