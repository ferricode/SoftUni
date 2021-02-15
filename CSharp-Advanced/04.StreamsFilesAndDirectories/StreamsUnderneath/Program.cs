using System;
using System.IO;

namespace StreamsUnderneath
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream stream = new FileStream("../../../students.txt", FileMode.Open))
            {
                byte[] buffer = new byte[409];
                //Console.WriteLine($"Stream position: {stream.Position}");

                for (int i = 0; i < stream.Length / buffer.Length; i++)
                {
                    stream.Read(buffer, 0, buffer.Length);

                    using (FileStream writerStream = new FileStream($"../../../students={i}.txt", FileMode.Create, FileAccess.Write))
                    {
                        writerStream.Write(buffer, 0, buffer.Length);
                    }


                    Console.Write($"{(char)buffer[0]}{(char)buffer[1]}");
                   
                }
            }
        }
    }
}
