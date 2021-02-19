using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());

            int taskToKill = int.Parse(Console.ReadLine());

            while (true)
            {
                int currTask = tasks.Pop();
                int currThread = threads.Peek();

                if (!(currThread >= currTask))
                {
                    
                    tasks.Push(currTask);
                }
                
                if (currTask == taskToKill)
                {

                    Console.WriteLine($"Thread with value {currThread} killed task {taskToKill}");
                    break;
                }
                else
                {
                    threads.Dequeue();
                }

            }

            Console.WriteLine(string.Join(" ", threads));

        }
    }
}
