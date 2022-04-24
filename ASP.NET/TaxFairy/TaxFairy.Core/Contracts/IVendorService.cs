using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxFairy.Core.ViewModels;

namespace TaxFairy.Core.Contracts
{
    public interface IVendorService
    {
        Task<IEnumerable<VendorListViewModel>> GetVendorList();
        Task<bool> CreateVendor(VendorCreateViewModel model);
        //Task<VendorEditViewModel> GetVendorToEdit(string id);
        //Task<bool> EditUser(VendorEditViewModel model);

    }
}
