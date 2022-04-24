using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using FootballManager.Contracts;
using FootballManager.Models;
using FootballManager.Models.Users;

namespace FootballManager.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayerService playerService;
        public PlayersController(Request request, IPlayerService _playerService)
            : base(request)
        {
            playerService = _playerService;
        }

        [Authorize]
        public Response Add() => View(new { IsAuthenticated = true });

        [HttpPost]
        [Authorize]
        public Response Add(CreatePlayersViewModel model)
        {
            var (created, error) = playerService.AddPlayer(model);

            if (!created)
            {
                return View(new { ErrorMessage = error }, "/Error");
            }

            return Redirect("/");
        }

        [Authorize]
        public Response All()
        {
            IEnumerable<CreatePlayersViewModel> players = playerService.GetPlayers();

            return View(players);
        }
        public Response AddUserToPlayer(int playerId)
        {
            try
            {
                playerService.AddUserToPlayer(playerId, User.Id);
            }
            catch (ArgumentException aex)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel(aex.Message) }, "/Error");
            }
            catch (Exception)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel("Unexpected Error") }, "/Error");
            }

            return Redirect("/Players/All");
        }
    }
}
