using System;
using System.Diagnostics;

namespace CustomHashTable
{
    class Program
    {
        static void Main(string[] args)
        {

            CoolHashSet table = new CoolHashSet(8, 75);

            //table.Add("aa");
            //table.Add("ab");
            //table.Add("zz");
            //table.Add("ca");
            //table.Add("dr");
            //table.Add("aazz");
            //table.Add("abzz");
            //table.Add("zzzz");
            //table.Add("cazz");
            //table.Add("drzz");

            
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 10000; i++)
            {
                table.Add($"{i}{i + 1}");
            }
            watch.Stop();
            Console.WriteLine($"Cool hashset adding time {watch.ElapsedMilliseconds}");
            watch.Reset();
            watch.Start();
            for (int i = 0; i < 10000; i++)
            {
                table.Contains($"{i}{i + 1}");
                table.Contains($"{i}{i + 1}{i}");
            }
            watch.Stop();
            Console.WriteLine($"Cool hashset contains time {watch.ElapsedMilliseconds}");

            //Console.WriteLine($"Contains: aa->{table.Contains("aa")}");
            //Console.WriteLine($"Contains: ab->{table.Contains("ab")}");
            //Console.WriteLine($"Contains: bez->{table.Contains("bez")}");

            //foreach (var item in table.internalArray)
            //{
            //    if (item == null)
            //    {
            //        Console.WriteLine("Empty Slot");
            //        continue;
            //    }
            //    Console.WriteLine(String.Join(",", item));
            //}
        }  }
}
