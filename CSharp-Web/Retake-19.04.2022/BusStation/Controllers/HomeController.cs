namespace BusStation.Controllers
{
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    public class HomeController : Controller
    {
        public HomeController(Request request)
          : base(request)
        {
        }

        public Response Index()

        {
            if (User.IsAuthenticated)
            {
                Redirect("/Destinations/All");

                //TODO:Add all destinations
            }
            return this.View(new { IsAuthenticated = false });
        }
    }
}
