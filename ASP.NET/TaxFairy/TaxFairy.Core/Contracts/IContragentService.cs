using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxFairy.Core.ViewModels;

namespace TaxFairy.Core.Contracts
{
    public interface IContragentService
    {
        Task<IEnumerable<ContragentListViewModel>> GetContragentList();
        Task<bool> CreateContragent(ContragentCreateViewModel model);
        Task<ContragentEditViewModel> GetContragentToEdit(string id);
        Task<bool> EditContragent(ContragentEditViewModel model);
    }
}
