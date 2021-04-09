using MilitaryElite.Contracts;
using MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<IMission> missions;
        public Commando(string id, string firstName, string lastName, decimal salary, SoldierCorpEnum soldierCorpEnum)
            : base(id, firstName, lastName, salary, soldierCorpEnum)
        {
            missions = new List<IMission>();
        }
        public IReadOnlyCollection<IMission> Missions => missions.AsReadOnly();
        public void AddMision(IMission mission)
        {
            missions.Add(mission);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");

            foreach (var mission in Missions)
            {
                sb.AppendLine($"  {mission}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

