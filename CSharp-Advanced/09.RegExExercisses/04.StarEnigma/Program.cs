using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            string decriptionPattern = @"[STARstar]";
           // string planetPattern = @"@([A-z]+).*[:](\d+)!([AD])!->(\d+)";
            string planetPattern = @"[^\@\-!:>]*@([A-z]+)[^\@\-!:>]*[:](\d+)[^\@\-!:>]*!([AD])![^\@\-!:>]*->(\d+)[^\@\-!:>]*";


            Regex decriptionRegex = new Regex(decriptionPattern);
            Regex regexPlanet = new Regex(planetPattern);

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                string line = Console.ReadLine();

                int decriptionCount = 0;

                MatchCollection matches = decriptionRegex.Matches(line);

                foreach (Match match in matches)
                {

                    decriptionCount++;

                }
                string decriptedLine = "";
                string newLine = "";
                int letter = 0;

                for (int k = 0; k < line.Length; k++)
                {

                    letter = line[k];

                    newLine += Convert.ToChar(letter - decriptionCount);
                }
               // Console.WriteLine(newLine);

                Match planetMatch = regexPlanet.Match(newLine);
                if (planetMatch.Success)
                {
                    string name = planetMatch.Groups[1].Value;
                    int population = int.Parse(planetMatch.Groups[2].Value);
                    char attackType = Convert.ToChar(planetMatch.Groups[3].Value);
                    int soldiers = int.Parse(planetMatch.Groups[4].Value);
                    if (attackType=='A')
                    {
                        attackedPlanets.Add(name);
                    }
                    else
                    {
                        destroyedPlanets.Add(name);
                    }
                }
                else
                {
                    continue;
                }

            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (var item in attackedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {item}");
            }
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (var item in destroyedPlanets.OrderBy(x=>x))
            {
                Console.WriteLine($"-> {item}");
            }
        }
    }
}