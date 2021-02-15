using System;
using System.Collections.Generic;
using System.Linq;

namespace _08CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, List<string>> company = new Dictionary<string, List<string>>();

            while (input.ToLower() != "end")
            {
                string[] tokens = input.Split(" -> ");
                string companyName = tokens[0];
                string id = tokens[1];

                if (company.ContainsKey(companyName))
                {
                    if (!company[companyName].Contains(id))
                    {

                        company[companyName].Add(id);

                    }

                }
                else
                {
                    company.Add(companyName, new List<string>());
                    company[companyName].Add(id);
                }

                input = Console.ReadLine();
            }
            foreach (var item in company.OrderBy(x => x.Key))
            {
                Console.WriteLine(item.Key);
                foreach (var element in item.Value)
                {
                    Console.WriteLine($"-- {element}");
                }
            }
        }
    }
}
