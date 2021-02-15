using System;
using System.Collections.Generic;

namespace _08.BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> open = new Stack<char>();
            string input = Console.ReadLine();

            bool isValid = true;

            if (input.Length== 0 || input.Length% 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }
            foreach (var item in input)
            {
                if (item == '(' || item == '{' || item == '[')
                {
                    open.Push(item);
                }
                else
                {
                    bool isFirstIsValid = item == ')' && open.Pop() == '(';
                    bool isSecondIsValid = item == '}' && open.Pop() == '{';
                    bool isThirsIsValid = item == ']' && open.Pop() == '[';

                    if (!(isFirstIsValid || isSecondIsValid || isThirsIsValid))
                    {
                        isValid = false;
                        break;
                    }
                }
            }
            if (isValid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
