using System;
using System.IO;

namespace StreamsAndFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"C:\Users\ferid\source\repos\04.StreamsFilesAndDirectories\StreamsAndFiles\input.txt");

            string line = reader.ReadLine();
           
            Console.WriteLine(line);
            reader.Close();
        }
    }
}
