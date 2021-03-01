using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings<string> myStack = new StackOfStrings<string>();
            myStack.IsEmpty();
            Console.WriteLine(myStack.IsEmpty());

            myStack.AddRange(new List<string>()
            {
                "123",
                "456",
                "789",
                "Gogi"
            });
                
            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }

        }
    }
}
