using System;
using System.Collections.Generic;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> books = new Stack<string>();

            books.Push("Pinokio");
            books.Push("War And Peace");
            books.Push("Alhimikyt");

            books.Pop();
            books.Pop();

            Console.WriteLine(books.Pop()); ;
        }
    }
}
