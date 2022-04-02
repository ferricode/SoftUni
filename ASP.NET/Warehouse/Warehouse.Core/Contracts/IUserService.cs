using Warehouse.Core.Models;

namespace Warehouse.Core.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserListViewModel>> GetUsers();
    }
}
