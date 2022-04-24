using BusStation.Contracts;
using BusStation.Data.Common;
using BusStation.Data.Models;
using BusStation.ViewModels;

namespace BusStation.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly IRepository repo;
        public DestinationService(IRepository _repo)
        {
            repo = _repo;
        }
        public IEnumerable<DestinationListViewModel> GetAllDestinations()
        {
       
            return repo.All<Destination>()
                     .Select(dest => new DestinationListViewModel
                     {
                         DestinationName = dest.DestinationName,
                         Origin = dest.Origin,
                         Date = dest.Date,
                         Time = dest.Time,
                         ImageUrl = dest.ImageUrl,
                         TicketsCount = dest.Tickets.Count
                     });
                    
        }

      
    }
}
