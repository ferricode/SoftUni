using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            //(?<day>(?:[0-2][0-9])|(?:3[0-1]))\/(?<month>(?:0[1-9])|(?:1[0-2]))\/(?<year>[0-9]{4})
            //\w+
            //(?:(?:[1-3]?[0-9])|(?:3[01]))-([A-Z][a-z]{2})-([0-9]{4})

            string pattern = @"\b[A-Z][a-z]+\b \b[A-Z][a-z]+\b";

            Regex regex = new Regex(pattern);

            string text = Console.ReadLine(); ;
            var mathces = regex.Matches(text);
            Console.WriteLine(string.Join(' ',mathces));
        }
    }
}
