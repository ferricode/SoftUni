using MilitaryElite.Contracts;
using MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");

            Dictionary<string, ISoldier> soldiersByID = new Dictionary<string, ISoldier>();

            string command;
           
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split();

                string soldierType = commandArgs[0];
                string id = commandArgs[1];
                string firstName = commandArgs[2];
                string lastName = commandArgs[3];

                if (soldierType == typeof(Private).Name)
                {
                    decimal salary = decimal.Parse(commandArgs[4]);
                    soldiersByID[id] = new Private(id, firstName, lastName, salary);
                }
                else if (soldierType == typeof(LieutenantGeneral).Name)
                {
                    decimal salary = decimal.Parse(commandArgs[4]);

                    ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);


                    for (int i = 5; i < commandArgs.Length; i++)
                    {
                        string privateId = commandArgs[i];

                        lieutenantGeneral.AddPrivate((IPrivate)soldiersByID[privateId]);
                    }

                    soldiersByID[id] = lieutenantGeneral;
                }
                else if (soldierType == typeof(Engineer).Name)
                {
                    //•	Engineer:
                    // Name: < firstName > < lastName > Id: < id > Salary: < salary > Corps: < corps >Repairs:
                    // < repair1 ToString() >
                    // < repair2 ToString() >
                    //< repairN ToString() >

                    decimal salary = decimal.Parse(commandArgs[4]);

                    bool isCorpsValid = Enum.TryParse(commandArgs[5], out SoldierCorpEnum corps);

                    if (!isCorpsValid)
                    {
                        continue;
                    }

                    IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < commandArgs.Length; i+=2)
                    {
                        string part = commandArgs[i];
                        int hoursWorked = int.Parse(commandArgs[i + 1]);

                        IRepair repair = new Repair(part, hoursWorked);

                        engineer.AddRepair(repair);
                    }

                    soldiersByID[id] = engineer;
                }
                else if (soldierType == typeof(Commando).Name)
                {
                    decimal salary = decimal.Parse(commandArgs[4]);

                    bool isCorpsValid = Enum.TryParse(commandArgs[5], out SoldierCorpEnum corps);

                    if (!isCorpsValid)
                    {
                        continue;
                    }

                    ICommando commando = new Commando(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < commandArgs.Length; i+=2)
                    {
                        string codeName = commandArgs[i];
                        string state = commandArgs[i + 1];

                        bool isMissionValid = Enum.TryParse(state, out MissionStateEnum missionState);

                        if (!isMissionValid)
                        {
                            continue;
                        }

                        IMission mission = new Mission(codeName, missionState);

                        commando.AddMision(mission);

                    }
                    soldiersByID[id] = commando;
                }
                else if (soldierType == typeof(Spy).Name)
                {
                    // •	Spy:
                    //Name: < firstName > < lastName > Id: < id >
                    //Code Number: < codeNumber >

                    int codeNumber = int.Parse(commandArgs[4]);

                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);

                    soldiersByID[id] = spy;
                }


            }

            foreach (var soldierr in soldiersByID.Values)
            {
                Console.WriteLine(soldierr);
            }

        }
    }
}
