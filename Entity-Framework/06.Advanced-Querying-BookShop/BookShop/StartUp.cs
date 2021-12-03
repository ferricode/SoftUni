namespace BookShop
{
    using Microsoft.EntityFrameworkCore;
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Globalization;

    public class StartUp
    {
        public static void Main()
        {
            using var dbContext = new BookShopContext();
            //DbInitializer.ResetDatabase(dbContext);

            //string ageRestrictionString = Console.ReadLine();

            //
            //string result = GetBooksByAgeRestriction(dbContext, ageRestrictionString);

            // int year = int.Parse(Console.ReadLine());

            //int  input = int.Parse(Console.ReadLine());
            //string result = GetMostRecentBooks(dbContext);

            //Console.WriteLine(result);

            //Stopwatch sw = new Stopwatch();
            //sw.Start();

            Console.WriteLine(RemoveBooks(dbContext));
            //Console.WriteLine(sw.ElapsedMilliseconds);
        }
        //02.Problem - Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            //Cannot be null
            AgeRestriction ageRestriction =
                Enum.Parse<AgeRestriction>(command, true);

            string[] bookTitle = context
                .Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();
            foreach (string title in bookTitle)
            {
                sb.AppendLine(title);
            }
            return sb.ToString().TrimEnd();

        }
        //3.Problem - Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            string[] goldenBooksTitles = context
            .Books
            .Where(b => b.EditionType == EditionType.Gold &&
                      b.Copies < 5000)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToArray();

            foreach (string title in goldenBooksTitles)
            {
                sb.AppendLine(title);
            }
            return sb.ToString().TrimEnd();
        }
        //4.Problem - Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var booksByPrice = context
            .Books
            .Where(b => b.Price > 40)
            .Select(b => new
            {
                b.Title,
                b.Price,
            })
            .OrderByDescending(b => b.Price)
            .ToArray();

            foreach (var book in booksByPrice)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        //5.Problem - Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();

            string[] bookNotReleased = context
                .Books
                .Where(b => b.ReleaseDate.HasValue &&
                           b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();
            foreach (string title in bookNotReleased)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }
        //6.Problem - Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {

            string[] categories = input
                                   .ToLower()
                                   .Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                   .ToArray();

            StringBuilder sb = new StringBuilder();

            string[] booksTitleByCategories = context.Books
                .Include(x => x.BookCategories)
                .ThenInclude(x => x.Category)
                .ToArray()
                .Where(b => b.BookCategories
                               .Any(c => categories.Contains(c.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToArray();

            foreach (string title in booksTitleByCategories)
            {
                sb.AppendLine(title);
            }


            return sb.ToString().TrimEnd();

        }
        //7.Problem - 7. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var beforeDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);


            var booksReleasedBeforeDate = context.Books
                                            .Where(b => b.ReleaseDate.Value < beforeDate)
                                            .Select(b => new
                                            {
                                                b.Title,
                                                b.EditionType,
                                                b.Price,
                                                b.ReleaseDate.Value
                                            })
                                            .OrderByDescending(b => b.Value)
                                            .ToArray();


            var result = string.Join(Environment.NewLine, booksReleasedBeforeDate.Select(book => $"{book.Title} - {book.EditionType} - ${book.Price:f2}"));



            return result;
        }
        //8.Problem - Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            string[] authorNames = context
                .Authors
                .ToArray()
                .Where(a => a.FirstName.ToLower().EndsWith(input.ToLower()))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .OrderBy(n => n)
                .ToArray();

            foreach (string authorName in authorNames)
            {
                sb.AppendLine(authorName);
            }

            return sb.ToString().TrimEnd();
        }

        //9.Problem - Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            string[] bookTitles = context
                .Books
                .ToArray()
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            foreach (string bookTitle in bookTitles)
            {
                sb.AppendLine(bookTitle);
            }

            return sb.ToString().TrimEnd();
        }

        //10.Problem - Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            string[] booksByAuthors = context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToArray();

            foreach (string book in booksByAuthors)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }
        //11.Problem - 11. Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            string[] booksCount = context
                   .Books
                   .Where(b => b.Title.Length > lengthCheck)
                   .Select(b => b.Title)
                   .ToArray();
            int result = booksCount.Count();

            return result;
        }
        //12.Problem - Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authorsWithBookCopies = context
                .Authors
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    TotalBookCopies = a
                                    .Books
                                    .Sum(b => b.Copies)

                })
                .OrderByDescending(a => a.TotalBookCopies)
                .ToArray();

            foreach (var author in authorsWithBookCopies)
            {
                sb.AppendLine($"{author.FullName} - {author.TotalBookCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        //13.Problem - Profit By Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {

            StringBuilder sb = new StringBuilder();

            var categoriesByProfit = context
                .Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    TotalProfit = c.CategoryBooks
                                .Sum(cb => cb.Book.Copies * cb.Book.Price)

                })
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.CategoryName)
                .ToArray();

            foreach (var category in categoriesByProfit)
            {
                sb.AppendLine($"{category.CategoryName} ${category.TotalProfit:f2}");
            }

            return sb.ToString().TrimEnd();
        }
        //14.Problem - Category Books

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categoriesWithMostRecentBooks = context
                .Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    MostRecentBooks = c.CategoryBooks
                                 .Select(cb => cb.Book)
                                 .OrderByDescending(b => b.ReleaseDate)
                                 .Take(3)
                                 .Select(b => new
                                 {
                                     BookTitle = b.Title,
                                     ReleaseDate = b.ReleaseDate.Value.Year
                                 })
                                 .ToArray()
                })
                .OrderBy(c => c.CategoryName)
                .ToArray();

            foreach (var category in categoriesWithMostRecentBooks)
            {
                sb.AppendLine($"--{category.CategoryName}");
                foreach (var book in category.MostRecentBooks)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.ReleaseDate})");
                }
            }
            return sb.ToString().TrimEnd();
        }

        //15.Probnlem - Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            IQueryable<Book> allBooksBefore2021 = context
                    .Books
                    .Where(b => b.ReleaseDate.HasValue &&
                               b.ReleaseDate.Value.Year < 2010);
            foreach (Book book in allBooksBefore2021)
            {
                book.Price += 5;
            }
            context.SaveChanges();

        }
        //16.Problem Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            var booksToRemove = context.Books
                            .Where(b => b.Copies < 4200)
                            .ToArray();
            int count = booksToRemove.Count();

            var booksCategoriesToRemove = context.BooksCategories
                .Where(bc => bc.Book.Copies < 4200)
                .ToList();

            context.BooksCategories.RemoveRange(booksCategoriesToRemove);
            context.Books.RemoveRange(booksToRemove);

            context.SaveChanges();

            return count;
        }

    }
}
