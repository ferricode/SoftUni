﻿using MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts
{
    public interface ISpecialisedSoldier:ISoldier
    {
        SoldierCorpEnum SoldierCorpEnum { get; }
    }
}
