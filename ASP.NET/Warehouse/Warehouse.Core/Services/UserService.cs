using Microsoft.EntityFrameworkCore;
using Warehouse.Core.Contracts;
using Warehouse.Core.Models;
using Warehouse.Infrastructure.Data.Identity;
using Warehouse.Infrastructure.Data.Repositories;

namespace Warehouse.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IApplicationDbRepository repo;
        public UserService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }
        public async Task<IEnumerable<UserListViewModel>> GetUsers()
        {
            return await repo.All<ApplicationUser>()
                .Select(u => new UserListViewModel()
                {
                    Email = u.Email,
                    Id = u.Id,
                    Name = $"{u.FirstName} {u.LastName}"
                })
                .ToListAsync();
        }
    }
}
