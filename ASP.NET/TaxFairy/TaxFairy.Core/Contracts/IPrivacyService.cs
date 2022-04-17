using TaxFairy.Core.Models;

namespace TaxFairy.Core.Contracts
{
    public interface IPrivacyService
    {
        Task<PrivacyEditViewModel> GetPrivacy();
    }
}
