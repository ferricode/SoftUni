using System;
using System.Text.RegularExpressions;

namespace _03.MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<day>(?:[1-3]?[0-9])|(?:3[01]))([\.\-\/])(?<month>[A-Z][a-z]{2})(\2)(?<year>[0-9]{4})";
            string dates = Console.ReadLine();


            var regex = new Regex(pattern);
            var matches = regex.Matches(dates);
            //Month: {month}, Year: {year}”

            foreach (Match match in matches)
            {
                Console.WriteLine($"Day: {match.Groups["day"]}, Month: {match.Groups["month"]}, Year: {match.Groups["year"]}" );
            }
        }
    }
}
