﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book
    {
        public Book(string title, int year, List<string> authors)
        {
            Title = title;
            Year = year;
            Authors = authors;

        }
        public string Title { get; private set; }
        public int Year { get; private set; }
        public List<string> Authors { get; private set; }
    }
}
