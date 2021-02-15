using System;
using System.Linq;
namespace _02.CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split(" ");
            string[] arr2 = Console.ReadLine().Split(" ");
            foreach (var elementTwo in arr2)
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    if (elementTwo == arr1[i])
                    {
                        Console.Write(elementTwo + " ");
                        break;
                    }
                }
            }
        }
    }
}
