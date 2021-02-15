using System;

namespace _09.GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            GetTypeMax(input);

        }
        private static void GetTypeMax(string input)
        {
            switch (input)
            {
                case "int":
                    int a = int.Parse(Console.ReadLine());
                    int b = int.Parse(Console.ReadLine());
                    GetMax(a, b);
                    break;
                case "char":
                    char aChar = char.Parse(Console.ReadLine());
                    char bChar = char.Parse(Console.ReadLine());
                    GetMax(aChar, bChar);
                    break;
                case "string":
                    string aString = Console.ReadLine();
                    string bString = Console.ReadLine();
                    GetMax(aString, bString);
                    break;

            }
        }
        
        private static void GetMax(int a, int b)
        {
            if (a > b)
            {
                Console.WriteLine(a);
            }
            else
            {
                Console.WriteLine(b);
            }
        }
        private static void GetMax(char a, char b)
        {
            if ((int)a > (int)b)
            {
                Console.WriteLine(a);
            }
            else
            {
                Console.WriteLine(b);
            }

        }
        private static void GetMax(string aString, string bString)
        {
            if (string.Compare(aString, bString) > 0)
            {
                Console.WriteLine(aString);
            }
            else if(string.Compare(aString, bString) < 0)
            {
                Console.WriteLine(bString);
            }
        }


    }
}
