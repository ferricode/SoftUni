using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
           Stack<string> text = new Stack<string>();


            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] command = input.Split().ToArray();
                int action = int.Parse(command[0]);

                switch (action)
                {
                    case 1:
                        string appendElement = command[1];
                        if (!text.Any())
                        {
                            text.Push(appendElement);
                        }
                        else
                        {
                            string text1 = text.Peek();
                            text.Push(text1 + appendElement);
                        }
                        break;
                    case 2:
                        int count = int.Parse(command[1]);
                        string text2 = text.Peek();
                        int length = text2.Length;
                        string newText = text2.Remove(length - count, count);
                        text.Push(newText);
                        break;
                    case 3:
                        int position = int.Parse(command[1]);
                        string text3 = text.Peek();
                        Console.WriteLine(text3[position - 1]);
                        break;
                    case 4:
                        text.Pop();
                        break;

                }


            }
        }
    }
}
