using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> players;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.players = new List<Player>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count =>players.Count; 

        public void AddPlayer(Player player)
        {
            if (players.Count < Capacity)
            {
                players.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            Player currPlayer = players.FirstOrDefault(p => p.Name == name);

            if (players.Contains(currPlayer))
            {
                players.Remove(currPlayer);
                return true;
            }
            return false;
        }
        public void PromotePlayer(string name)
        {
            Player currPlayer = players.FirstOrDefault(p => p.Name == name);

            if (players.Contains(currPlayer))
            {
                if (currPlayer.Rank != "Member")
                {
                    currPlayer.Rank = "Member";
                }

            }
        }
        public void DemotePlayer(string name)
        {
            Player currPlayer = players.FirstOrDefault(p => p.Name == name);

            if (players.Contains(currPlayer))
            {
                if (currPlayer.Rank != "Trial")
                {
                    currPlayer.Rank = "Trial";
                }

            }

        }
        public Player[] KickPlayersByClass(string @class)
        {
            Player[] classArray = players.Where(p => p.Class == @class).ToArray();

            foreach (var player in classArray)
            {
                players.Remove(player);
            }
            return classArray;
        }
        public string Report()
        {
            StringBuilder res = new StringBuilder();
            res.AppendLine($"Players in the guild: {Name}");

            foreach (var player in players)
            {
                res.AppendLine(player.ToString());
            }
            return res.ToString().Trim();

        }
    }
}
