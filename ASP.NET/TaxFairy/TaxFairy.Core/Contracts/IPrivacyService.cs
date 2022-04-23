using TaxFairy.Core.ViewModels;

namespace TaxFairy.Core.Contracts
{
    public interface IPrivacyService
    {
        Task<PrivacyEditViewModel> GetPrivacy();
        Task<NewsViewModel> GetPrivacyToEdit(string id);
    }
}
