using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Problem 1
            //string name = Console.ReadLine();
            //int age = int.Parse(Console.ReadLine());
            //IPerson person = new Citizen(name, age);
            //Console.WriteLine(person.Name);
            //Console.WriteLine(person.Age);

            //Problem 2
            //string name = Console.ReadLine();
            //int age = int.Parse(Console.ReadLine());
            //string id = Console.ReadLine();
            //string birthdate = Console.ReadLine();
            //IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
            //IBirthable birthable = new Citizen(name, age, id, birthdate);
            //Console.WriteLine(identifiable.Id);
            //Console.WriteLine(birthable.Birthdate);

            List<IIdentifiable> identifiables = new List<IIdentifiable>();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }
                string[] parts = line.Split();

                if (parts.Length==3)
                {
                    string name = parts[0];
                    int age = int.Parse(parts[1]);
                    string id = parts[2];
                    identifiables.Add(new Citizen(name, age, id));
                }
                else
                {
                    string model = parts[0];
                    string id = parts[1];

                    identifiables.Add(new Robot(model, id));
                }
            
            }
            string filterId = Console.ReadLine();

            List<IIdentifiable> filtered = identifiables.Where(i => i.Id.EndsWith(filterId)).ToList();

            foreach (var identifiable in filtered)
            {
                Console.WriteLine(identifiable.Id);
            }
        }
    }
}
