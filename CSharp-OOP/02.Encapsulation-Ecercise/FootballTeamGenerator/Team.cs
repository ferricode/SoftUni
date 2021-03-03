using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private Dictionary<string, Player> playersByName;

        public Team(string name)
        {
            this.Name = name;
            playersByName = new Dictionary<string, Player>();
        }

        public string Name
        {
            get => name;
            private set
            {
                Validator.ThrowIfStringIsNullOrWhiteSpace(value, GlobalConstants.InvalidNameErrorMessage);
                this.name = value;
            }
        }
        public double AverageRating
        {
            get
            {
                if (playersByName.Count == 0)
                {
                    return 0;
                }
                return Math.Round(playersByName.Values.Average(p => p.AverageSkillPoints));
            }
        }
        public void AddPlayer(Player player)
        {
            playersByName.Add(player.Name, player);
        }
        public void RemovePlayer(string playerName)
        {
            if (!playersByName.ContainsKey(playerName))
            {
                throw new InvalidOperationException($"Player {playerName} is not in {Name} team.");
            }
            this.playersByName.Remove(playerName);
        }


    }
}
