using MilitaryElite.Contracts;
using MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, SoldierCorpEnum soldierCorpEnum)
            : base(id, firstName, lastName, salary)
        {
            this.SoldierCorpEnum = soldierCorpEnum;
        }

        public SoldierCorpEnum SoldierCorpEnum { get; }

        public override string ToString()
        {
            return base.ToString() +
                Environment.NewLine +
                $"Corps: {SoldierCorpEnum}";
        }
    }
}
