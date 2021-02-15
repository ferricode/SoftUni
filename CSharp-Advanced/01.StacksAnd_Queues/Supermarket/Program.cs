using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Queue<string> clients = new Queue<string>();
            int count=0;

            while (input!="End")
            {
                if (input=="Paid")
                {
                    int num = clients.Count;
                    for (int i = 0; i <num; i++)
                    {
                        Console.WriteLine(clients.Dequeue());
                        count--;
                    }
                }
                else
                {
                    clients.Enqueue(input);
                    count++;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{count} people remaining.");
        }
    }
}
