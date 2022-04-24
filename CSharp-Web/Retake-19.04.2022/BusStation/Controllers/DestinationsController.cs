using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using BusStation.Contracts;
using BusStation.ViewModels;

namespace BusStation.Controllers
{
    public class DestinationsController : Controller
    {
        private readonly IDestinationService service;
        public DestinationsController(Request request, IDestinationService _service) 
            : base(request)
        {
            service = _service;
        }

        [Authorize]
        public Response All()
        {
           IEnumerable<DestinationListViewModel> destinations = service.GetAllDestinations();
            return View(destinations);
        }
    }
}
