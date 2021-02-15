using System;
using System.Collections.Generic;

namespace _07.Workshop_ImplementingStacksAndQueues
{
    class Program
    {
        static void Main(string[] args)
        {


            CustomList myList = new CustomList();

            CustomStack myStack = new CustomStack();
            myStack.Push(10);
            myStack.Push(20);
            myStack.Push(30);
            myStack.Push(40);

            myStack.MySelect(e => e * 10);
            myStack.ForEach(e => Console.WriteLine(e));


        }
    }
}
