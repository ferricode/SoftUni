using FootballManager.Contracts;
using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.Models.Users;

namespace FootballManager.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public PlayerService(IRepository _repo, IValidationService _validationService)
        {
            repo = _repo;
            validationService = _validationService;
        }
        public (bool created, string error) AddPlayer(CreatePlayersViewModel model)
        {
            bool created = false;
            string error = String.Empty;

            var (isValid, validationError) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, validationError);

            }
            var player = new Player()
            {
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
                Position = model.Position,
                Speed = model.Speed,
                Description = model.Description,
                Endurance = model.Endurance

            };

            //if (repo.All<Player>().FirstOrDefault(p => p.FullName == player.FullName) != null)
            //{
            //    return (created, error);
            //}

            try
            {

                repo.Add(player);
                repo.SaveChanges();
                created = true;
            }
            catch (Exception)
            {
                error = $"Could not save player";
            }

            return (created, error);

        }
        public void AddUserToPlayer(int playerId, string id)
        {
            User? user = repo.All<User>()
                .FirstOrDefault(u => u.Id == id);

            Player? player = repo.All<Player>()
                .FirstOrDefault(p => p.Id == playerId);

            if (user == null || player == null)
            {
                throw new ArgumentException("User or player is not found");
            }

            user.UserPlayers.Add(new UserPlayer()
            {
                PlayerId = playerId,
                Player = player,
                User = user,
                UserId = id
            });

            repo.SaveChanges();
        }

        public IEnumerable<CreatePlayersViewModel> GetPlayers()
        {
            return repo.All<Player>()
                .Select(p => new CreatePlayersViewModel()
                {

                    ImageUrl = p.ImageUrl,
                    Description = p.Description,
                    FullName = p.FullName,
                    Position = p.Position,
                    Speed = p.Speed,
                    Endurance = p.Endurance
                })
                .ToList();
        }
    }
}
