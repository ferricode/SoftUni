using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxFairy.Core.ViewModels;

namespace TaxFairy.Core.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserListViewModel>> GetUsersList();
        Task<UserEditViewModel> GetUserToEdit(string id);
        Task<bool> EditUser(UserEditViewModel model);

    }
}
