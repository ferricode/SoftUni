using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split(" ").Skip(1).ToList();
            ListyIterator<string> list = new ListyIterator<string>(items);

            string command = Console.ReadLine();
            while (command!="END")
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(list.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;
                    case "Print":
                        try
                        {

                        }
                        catch (InvalidOperationException ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                        list.Print();
                        break;
                    case "PrintAll":
                        foreach (string item in list)
                        {
                            Console.Write(item+" ");
                        }
                        Console.WriteLine();
                        break;
                }
                command = Console.ReadLine();
            }

            //list.Print();
            //Console.WriteLine(list.HasNext());
            //Console.WriteLine(list.Move());
            //Console.WriteLine(list.Move());
        }
    }
}
