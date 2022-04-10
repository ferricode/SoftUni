using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxFairy.Core.Contracts;
using TaxFairy.Core.Models;
using TaxFairy.Infrastructure.Data.Identity;
using TaxFairy.Infrastructure.Repositories;

namespace TaxFairy.Core.Services
{
    public class UserService : IUserService
    {
        private readonly ITaxFairyDbRepository repo;


        public UserService(ITaxFairyDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<UserEditViewModel> GetUserToEdit(string id)
        {
            var user = await repo.GetByIdAsync<ApplicationUser>(id);

            return new UserEditViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                FullName = user.FullName,
                Email = user.Email
            };
        }

        public async Task<IEnumerable<UserListViewModel>> GetUsersList()
        {
            return await repo.All<ApplicationUser>()
                .Select(u => new UserListViewModel()
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    FullName = u.FullName,
                    Email = u.Email,

                })
                .ToListAsync();
        }

        public async Task<bool> EditUser(UserEditViewModel model)
        {
            bool result = false;
            var user = await repo.GetByIdAsync<ApplicationUser>(model.Id);

            if (user != null)
            {
                user.UserName = model.UserName;
                user.FullName = model.FullName;
                user.Email = model.Email;

                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }
    }
}
