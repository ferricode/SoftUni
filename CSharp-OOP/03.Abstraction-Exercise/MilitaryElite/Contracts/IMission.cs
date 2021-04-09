using MilitaryElite.Enumerations;


namespace MilitaryElite.Contracts
{ 
    public interface IMission
    {
        string CodeName { get; }
        MissionStateEnum MissionState { get; }

        void CompleteMission(string missionName);
    }
}
