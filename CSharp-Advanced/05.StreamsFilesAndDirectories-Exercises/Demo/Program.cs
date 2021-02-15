using System;
using System.IO;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader=new StreamReader("text.txt"))
            {
                reader.ReadLine();
            }
            using StreamWriter streamWriter = new StreamWriter("result.txt");
        }
    }
}
