namespace EasterRaces.IO
{
    using System;
    using System.IO;
    using Contracts;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message)
        {
           // File.AppendAllText("../../../proveri.txt", message + Environment.NewLine);

            Console.WriteLine(message);
        }

        public void Write(string message)
        {
            Console.Write(message);
        }
    }
}