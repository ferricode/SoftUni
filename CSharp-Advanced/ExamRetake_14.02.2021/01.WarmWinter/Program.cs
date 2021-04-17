using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());

            Queue<int> scarfs = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());

            List<int> sets = new List<int>();

            int set = 0;

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                int hat = hats.Peek();
                int scarf = scarfs.Peek();

                if (hat > scarf)
                {
                    set = hat + scarf;
                    sets.Add(set);
                    hats.Pop();
                    scarfs.Dequeue();
                }
                if (scarf == hat)
                {
                    scarfs.Dequeue();
                    hat++;
                    hats.Pop();
                    hats.Push(hat);
                }
                if (scarf > hat)
                {
                    hats.Pop();
                    
                }
               

            }


            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ",sets));

        }
    }
}
