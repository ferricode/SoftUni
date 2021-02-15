using System;

namespace _06.CalculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            RectangleArea(a,b);
        }
        private static void RectangleArea(int a, int b)
        {
            int result = a * b;
            Console.WriteLine(result);
        }
    }
}
