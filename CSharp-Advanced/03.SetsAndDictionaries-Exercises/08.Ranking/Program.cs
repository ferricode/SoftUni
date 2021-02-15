using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestsData = new Dictionary<string, string>();

            string contestInput = Console.ReadLine();

            while (contestInput != "end of contests")
            {
                string[] contestData = contestInput.Split(":");
                contestsData.Add(contestData[0], contestData[1]);

                contestInput = Console.ReadLine();
            }

            SortedDictionary<string, Dictionary<string, int>> userSubmission = new SortedDictionary<string, Dictionary<string, int>>();
            string submissionsInput = Console.ReadLine();

            while (submissionsInput != "end of submissions")
            {
                string[] submissionData = submissionsInput.Split("=>");
                string contest = submissionData[0];
                string password = submissionData[1];
                string username = submissionData[2];
                int points = int.Parse(submissionData[3]);

                if (!contestsData.ContainsKey(contest) || contestsData[contest] != password)
                {
                    submissionsInput = Console.ReadLine();
                    continue;
                }
                if (!userSubmission.ContainsKey(username))
                {
                    userSubmission.Add(username, new Dictionary<string, int>());
                }
                if (!userSubmission[username].ContainsKey(contest))
                {
                    userSubmission[username].Add(contest, points);
                }
                else
                {
                    int oldPoints = userSubmission[username][contest];

                    if (points > oldPoints)
                    {
                        userSubmission[username][contest] = points;
                    }
                }

                submissionsInput = Console.ReadLine();
            }
            KeyValuePair<string, Dictionary<string, int>> bestCandidate=
                userSubmission.OrderByDescending(kvp => kvp.Value.Values.Sum()).First();

            int totalPoints = bestCandidate.Value.Values.Sum();

            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {totalPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var user in userSubmission )    
            {
                Console.WriteLine(user.Key);

                foreach (var contestData in user.Value.OrderByDescending(kvp=>kvp.Value))
                {
                    Console.WriteLine($"#  {contestData.Key} -> {contestData.Value}");
                }
            }
        }
    }
}
