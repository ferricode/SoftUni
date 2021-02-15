using System;

namespace _03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> myStack = new MyStack<int>();
       

            string commandData = Console.ReadLine();
            while (commandData!="END")
            {
                string[] commandArgs = commandData.Split(new string[] { " ", ", " },StringSplitOptions.RemoveEmptyEntries);
                string command = commandArgs[0];

                if (command=="Push")
                {
                    for (int i = 1; i < commandArgs.Length; i++)
                    {
                        int element = int.Parse(commandArgs[i]);
                        myStack.Push(element);

                    }
                }
                else if (command=="Pop")
                {
                    myStack.Pop();
                }
                commandData = Console.ReadLine();
            }

            foreach (var element in myStack)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine(string.Join(Environment.NewLine,myStack));
            //Console.WriteLine(myStack.Pop());
            //Console.WriteLine(myStack.Pop());
            //Console.WriteLine(myStack.Pop());
            //Console.WriteLine(myStack.Pop());

        }

    }
}
