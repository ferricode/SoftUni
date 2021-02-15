using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<day>(?:[1-3]?[0-9])|(?:3[01]))-(?<month>[A-Z][a-z]{2})-(?<year>[0-9]{4})";
            string whitespace = @"\s+";
            var regex = new Regex(pattern);


            // string text = "Today is 25-Nov-2020";
            string text = "2     4 3  1 6  4 3            8";

            int[] arr = Regex.Split(text, whitespace)
                     //.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse)
                     .ToArray();

            //// var match = regex.Match(text);
            //text= regex.Replace(text, "today");

            ////Console.WriteLine(regex.IsMatch(text));
            //Console.WriteLine(text);
        }
    }
}
