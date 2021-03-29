using System;
using System.Text;

namespace CreateInstance
{
    class Program
    {
        static void Main(string[] args)
        {
            Type sbType = typeof(StringBuilder);

            StringBuilder sb = (StringBuilder)Activator.CreateInstance(sbType);

            sb.Append("Hello");
            Console.WriteLine(sb);
        }
    }
}
