using System;
using System.Text;

namespace _06.ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            var sb = new StringBuilder();

            for (int i=0; i < input.Length - 1; i++)
            {
                if (input[i]!=input[i+1])
                {
                    sb.Append(input[i]);
                }

            }
            var symbol = input[input.Length - 1];
            sb.Append(symbol);

            Console.WriteLine(sb.ToString());
        }
    }
}
