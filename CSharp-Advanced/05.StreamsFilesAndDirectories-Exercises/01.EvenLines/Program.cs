using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "../../../text.txt";
            string pattern = @"[-,.!?]";

            using (StreamReader reader = new StreamReader("text.txt"))
            {

                using (StreamWriter writer=new StreamWriter("output.txt"))
                {
                    string line = reader.ReadLine();
                    int counter = 0;

                    while (line != null)
                    {
                        if (counter++ % 2 == 0)
                        {
                            string replacedLine = Regex.Replace(line, pattern, "@");

                            string[] words = replacedLine.Split(new string[] { " " },
                                StringSplitOptions.RemoveEmptyEntries);

                            writer.WriteLine(string.Join(" ", words.Reverse()));
                            Console.WriteLine(string.Join(" ", words.Reverse()));

                        }

                        line = reader.ReadLine();
                    }
                }
            };
        }
    }
}
