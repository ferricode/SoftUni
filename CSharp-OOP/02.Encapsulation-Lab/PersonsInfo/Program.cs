using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Problem 1
            //int n = int.Parse(Console.ReadLine());
            //List<Person> people = new List<Person>();

            //for (int i = 0; i < n; i++)
            //{
            //    var input = Console.ReadLine().Split();
            //    people.Add(new Person(input[0], input[1], int.Parse(input[2])));
            //}
            //people=people.OrderBy(p => p.FirstName).ThenBy(p => p.Age).ToList();

            //foreach (var person in people)
            //{
            //    Console.WriteLine(person);

            try
            {
                var lines = int.Parse(Console.ReadLine());
                var persons = new List<Person>();
                for (int i = 0; i < lines; i++)
                {
                    var cmdArgs = Console.ReadLine().Split();

                    var person = new Person(cmdArgs[0],
                                            cmdArgs[1],
                                            int.Parse(cmdArgs[2]),
                                            decimal.Parse(cmdArgs[3]));
                    persons.Add(person);
                }
                Team team = new Team("DreamTeam");
                persons.ForEach(p => team.AddPlayer(p));
                Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
                Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            };


            //Team team = new Team("SoftUni");

            //foreach (Person person in persons)
            //{
            //    team.AddPlayer(person);
            //}



            //Console.WriteLine(team.FirstTeam.Count);
            //Console.WriteLine(team.ReserveTeam.Count);
        }


    }
}
