using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            HashSet<Person> people = new HashSet<Person>();

            SortedSet<Person> sortedPeople = new SortedSet<Person>();

            int n = int.Parse(Console.ReadLine( ));

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine().Split();
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                Person person = new Person(name, age);
                people.Add(person);
                sortedPeople.Add(person);
            }
            Console.WriteLine(people.Count);
            Console.WriteLine(sortedPeople.Count);
       
            //5.
            //List<Person> people = new List<Person>();

            //string command = Console.ReadLine();
            //while (command != "END")
            //{
            //    string[] personInfo = command.Split().ToArray();

            //    string name = personInfo[0];
            //    int age = int.Parse(personInfo[1]);
            //    string city = personInfo[2];

            //    Person person = new Person(name, age, city);

            //    people.Add(person);

            //    command = Console.ReadLine();
            //}
            //int n = int.Parse(Console.ReadLine());

            //Person targetPerson = people[n - 1];

            //int matches = 1;

            //foreach (var person in people)
            //{
            //    if (person.CompareTo(targetPerson) == 0 && !person.Equals(targetPerson))
            //    {
            //        matches++;
            //    }
            //}
            //if (matches==1)
            //{
            //    Console.WriteLine("No matches");
            //}
            //else
            //{
            //    Console.WriteLine($"{matches} {people.Count-matches} {people.Count}");
            //}
        }
    }
}
