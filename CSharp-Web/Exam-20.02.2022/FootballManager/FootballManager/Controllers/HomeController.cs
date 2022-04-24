namespace FootballManager.Controllers
{
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using FootballManager.Contracts;
    using FootballManager.Models.Users;

    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly IPlayerService playerService;
        public HomeController(Request request,
            IPlayerService _playerService,
            IUserService _userService)

            : base(request)
        {
            playerService = _playerService;
            userService = _userService;
        }
        
        public Response Index()
        {
            if (User.IsAuthenticated)
            {
                string username = userService.GetUsername(User.Id);

                if (playerService.GetPlayers()!=null)
                {
                    var model = new
                    {
                        Username = username,
                        IsAuthenticated = true,
                        Players = playerService.GetPlayers()

                    };
                    return View(model, "/Players/All");
                }

                return View("/Players/All");
                //return View("/");
            };

            return View(new { IsAuthenticated = false });
        }
    }
}
