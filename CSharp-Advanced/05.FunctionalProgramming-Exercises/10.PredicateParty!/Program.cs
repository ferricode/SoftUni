using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> lengthFunc = (name, length) => name.Length == length;
            Func<string, string, bool> startsWithFunc = (name, patern) => name.StartsWith(patern);
            Func<string, string, bool> endsWithFunc = (name, patern) => name.EndsWith(patern);

            List<string> names = Console.ReadLine()
                .Split()
                .ToList();

            string command = Console.ReadLine();

            while (command != "Party!")
            {
                string[] commanData = command.Split();
                string action = commanData[0];
                string condition = commanData[1];
                string param = commanData[2];

                if (action == "Double")
                {
                    if (condition == "Length")
                    {
                        int length = int.Parse(param);
                        var tempNames = names.Where(name => lengthFunc(name, length)).ToList();
                        ArangedAddRange(names, tempNames);
                    }
                    else if (condition == "StartsWith")
                    {

                        var tempNames = names.Where(name => startsWithFunc(name, param)).ToList();
                        ArangedAddRange(names, tempNames);
                    }
                    else if (condition == "EndsWith")
                    {

                        var tempNames = names.Where(name => endsWithFunc(name, param)).ToList();
                        ArangedAddRange(names, tempNames);
                    }

                }
                else if (action == "Remove")
                {
                    if (condition == "Length")
                    {
                        int length = int.Parse(param);
                        names = names.Where(name => !lengthFunc(name, length)).ToList();

                    }
                    else if (condition == "StartsWith")
                    {

                        names = names.Where(name => !startsWithFunc(name, param)).ToList();

                    }
                    else if (condition == "EndsWith")
                    {

                        names = names.Where(name => !endsWithFunc(name, param)).ToList();

                    }
                }
                command = Console.ReadLine();
            }
            if (names.Count>0)
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

            static void ArangedAddRange(List<string> names, List<string> tempNames)
            {
                foreach (var currentName in tempNames)
                {
                    int index = names.IndexOf(currentName);
                    names.Insert(index, currentName);
                }
            }
        }
    }
}
