using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> app =
                new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            //app.Add("User one", new Dictionary<string, SortedSet<string>>());

            //app["User one"].Add("following", new SortedSet<string>());
            //app["User one"].Add("followers", new SortedSet<string>());

            string commandInput = Console.ReadLine();

            while (commandInput != "Statistics")
            {
                string[] commandData = commandInput.Split(" ");
                string vloggerName = commandData[0];
                string command = commandData[1];




                if (command == "joined")
                {
                    if (!app.ContainsKey(vloggerName))
                    {
                        app.Add(vloggerName, new Dictionary<string, SortedSet<string>>());
                        app[vloggerName].Add("following", new SortedSet<string>());
                        app[vloggerName].Add("followers", new SortedSet<string>());
                    }
                }
                else if (command == "followed")
                {

                    string vloggerTwoName = commandData[2];

                    if (app.ContainsKey(vloggerName) && app.ContainsKey(vloggerTwoName) && vloggerName != vloggerTwoName)
                    {
                        app[vloggerName]["following"].Add(vloggerTwoName);
                        app[vloggerTwoName]["followers"].Add(vloggerName);
                    }
                }

                commandInput = Console.ReadLine();
            }
            var sortedDataApp = app.OrderByDescending(kvp => kvp.Value["followers"].Count())
                                .ThenBy(kvp => kvp.Value["following"].Count())
                                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            Console.WriteLine($" The V-Logger has a total of {app.Count} vloggers in its logs.");
            int counter = 0;

            foreach (KeyValuePair<string, Dictionary<string, SortedSet<string>>> item in sortedDataApp)
            {
                int folowersCount = item.Value["followers"].Count;
                int folowingCount = item.Value["following"].Count;

                Console.WriteLine($"{++counter}. {item.Key} : {folowersCount} followers, {folowingCount} following");

                if (counter == 1)
                {
                    foreach (string follower in item.Value["followers"])
                    {
                        Console.WriteLine($"*  {follower}");
                    }

                }
            }
        }
    }
}
