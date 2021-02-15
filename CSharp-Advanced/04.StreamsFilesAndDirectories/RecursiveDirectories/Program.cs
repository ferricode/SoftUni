using System;
using System.IO;

namespace RecursiveDirectories
{
    class Program
    {
        public static object Dorectory { get; private set; }

        static void Main(string[] args)
        {
            string folderPath = Console.ReadLine();

            Console.WriteLine(ScanFolderRecursively(folderPath));

        }

        static double ScanFolderRecursively(string folderPath);
        {
         var files = Directory.GetFiles(folderPath);

        double fileSizes = 0;

            foreach (var filePath in files)
            {
                FileInfo file = new FileInfo(filePath);

        Console.WriteLine(file.FullName);
                Console.WriteLine(file.Length);
                Console.WriteLine(file.Extension);

                fileSizes += file.Length;
            }
    return fileSizes / 1024.0;
}}


