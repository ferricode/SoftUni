using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace _01.EncryptSortAndPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int[] arr = new int[number];

            for (int j = 0; j < number; j++)
            {
                int sum = 0;
                string name = Console.ReadLine();
                char[] letter = name.ToCharArray();


                for (int i = 0; i < letter.Length; i++)
                {
                    if ("aeiou".Contains(letter[i]) || "AEIOU".Contains(letter[i]))
                    {
                        sum += (int)letter[i] * name.Length;
                    }
                    else if ("bcdfghjklmnpqrstvwxyz".Contains(letter[i]) || "BCDFGHJKLMNPQRSTVWXYZ".Contains(letter[i]))
                    {
                        sum += (int)letter[i] / name.Length;
                    }
                }

                arr[j] = sum;

            }
            for (int i = 0; i < arr.Length; i++)
            {

                for (int j = 0; j < arr.Length - 1; j++)
                {

                    if (arr[j] > arr[j + 1])
                    {
                        int currentInt = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = currentInt;
                    }
                }
            }
            Console.WriteLine(string.Join("\n", arr));
        }
    }
}
