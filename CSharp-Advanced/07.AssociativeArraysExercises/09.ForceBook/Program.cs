using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> forceUsers = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();


            while (input.ToLower() != "lumpawaroo")
            {
                string[] cmdArgs = input.Split(new string[] {" | "," -> "},StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (input.Contains("|"))
                {
                    string side = cmdArgs[0];
                    string user = cmdArgs[1];

                    if (!forceUsers.ContainsKey(side))
                    {
                        forceUsers[side] = new List<string>();
                    }
                    if (!forceUsers.Values.Any(l => l.Contains(user)))
                    {
                        forceUsers[side].Add(user);
                    }

                }
                else if (input.Contains("->"))
                {
                    string user = cmdArgs[0];
                    string side = cmdArgs[1];

                    foreach (var kvp in forceUsers)
                    {
                        if (kvp.Value.Contains(user))
                        {
                            kvp.Value.Remove(user);
                        }

                    }
                    if (!forceUsers.ContainsKey(side))
                    {
                        forceUsers[side] = new List<string>();
                    }

                    forceUsers[side].Add(user);
                    Console.WriteLine($"{user} joins the {side} side!");

                }
                input = Console.ReadLine();
            }
            Dictionary<string, List<string>> orderedForceUsers = forceUsers
                                                                    .Where(kvp => kvp.Value.Count > 0)
                                                                    .OrderByDescending(kvp => kvp.Value.Count)
                                                                    .ThenBy(kvp => kvp.Key)
                                                                    .ToDictionary(a => a.Key, b => b.Value);

            foreach (var kvp in orderedForceUsers)
            {
                string currentSide = kvp.Key;
                List<string> currentSideUsers = kvp.Value.OrderBy(u => u).ToList();
                Console.WriteLine($"Side: {currentSide}, Members: {currentSideUsers.Count}");

                foreach (string user in currentSideUsers)
                {
                    Console.WriteLine($"! {user}");
                }

            }



        }
    }
}

