using System;
using System.IO.Compression;

namespace _06.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
           using ZipArchive zipFile = ZipFile.Open("zipFile.zip", ZipArchiveMode.Create);
           ZipArchiveEntry zipArchive= zipFile.CreateEntryFromFile("output.txt", "outputEntry.txt");
        }
    }
}
