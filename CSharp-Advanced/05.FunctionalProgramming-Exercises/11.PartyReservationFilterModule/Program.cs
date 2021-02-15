using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PartyReservationFilterModule_
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> lengthFunc = (name, length) => name.Length == length;
            Func<string, string, bool> startsWithFunc = (name, patern) => name.StartsWith(patern);
            Func<string, string, bool> endsWithFunc = (name, patern) => name.EndsWith(patern);
            Func<string, string, bool> contains = (name, patern) => name.Contains(patern);

            List<string> names = Console.ReadLine()
                .Split()
                .ToList();

            string command = Console.ReadLine();

            List<string> filters = new List<string>();

            while (command != "Print")
            {
                string[] commanData = command.Split(";");
                string action = commanData[0];
                string condition = commanData[1];
                string param = commanData[2];

                if (action == "Add filter")
                {
                    filters.Add($"{condition};{param}");
                }
                else if (action == "Remove filter")
                {
                    filters.Remove($"{condition};{param}");
                }
                command = Console.ReadLine();
            }
            foreach (var filterLine in filters)
            {
                string[] tokens = filterLine.Split(";");
                string condition = tokens[0];
                string param = tokens[1];

                switch (condition)
                {
                    case "Length":
                        int length = int.Parse(param);
                        names = names.Where(name => !lengthFunc(name, length)).ToList();
                        break;
                    case "Starts with":
                        names = names.Where(name => !startsWithFunc(name, param)).ToList();
                        break;
                    case "Ends with":
                        names = names.Where(name => !endsWithFunc(name, param)).ToList();
                        break;
                    case "Contains":
                        names = names.Where(name => !contains(name, param)).ToList();
                        break;
                }
               
            }
            Console.WriteLine(string.Join(" ", names));

        }
    }
}

       
       
            