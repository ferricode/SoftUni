using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.LootBox
{
    class Program
    {
        static void Main(string[] args)
        {

            Queue<int> lootBox1 = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());

            Stack<int> lootBox2 = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());

            int claimedItems = 0;

            while (lootBox1.Count > 0 && lootBox2.Count > 0)
            {
                int item1 = lootBox1.Peek();
                int item2 = lootBox2.Pop();
                int sum = item1 + item2;

                if (sum % 2 == 0)
                {
                    claimedItems += sum;
                }
                else
                {

                    lootBox1.Enqueue(item1);
                    continue;
                }
                lootBox1.Dequeue();
            }
            if (lootBox1.Count==0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            if (lootBox2.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }
            if (claimedItems>=100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems}");
            }
        }
    }
}
