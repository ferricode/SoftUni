using MilitaryElite.Contracts;
using MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Mission : IMission
    {
        public Mission(string codeName, MissionStateEnum missionStateEnum)
        {
            CodeName = codeName;
            MissionState = missionStateEnum;
        }

        public string CodeName { get; private set; }

        public MissionStateEnum MissionState { get; private set; }

        public void CompleteMission(string missionName)
        {
            MissionState = MissionStateEnum.Finished;
        }
        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {MissionState}";
        }
    }
}
