using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.OrderedByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Person> persons = new List<Person>();

            while (command != "End")
            {
                string[] cmdArgs = command.Split();
                string name = cmdArgs[0];
                string id = cmdArgs[1];
                int age = int.Parse(cmdArgs[2]);

                Person person = new Person(name, id, age);

                persons.Add(person);
                command = Console.ReadLine();
            }
            persons = persons.OrderBy(x => x.Age).ToList();

            foreach (Person currentPerson in persons)
            {
                Console.WriteLine(currentPerson);
            }
        }
    }
    class Person
    {
        public Person(string name, string iD, int age)
        {
            Name = name;
            ID = iD;
            Age = age;
        }

        public string Name { get; set; }

        public string ID { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }

}
