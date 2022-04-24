using FootballManager.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Contracts
{
    public interface IPlayerService
    {
        (bool created, string error) AddPlayer(CreatePlayersViewModel model);
        IEnumerable<CreatePlayersViewModel> GetPlayers();
        void AddUserToPlayer(int playerId, string id);
    }
}
