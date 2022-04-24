using BusStation.ViewModels;

namespace BusStation.Contracts
{
    public interface IDestinationService
    {
      
       // void AddDestination(DestinationViewModel model);
        IEnumerable<DestinationListViewModel> GetAllDestinations();
    }
}
