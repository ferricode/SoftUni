using Microsoft.EntityFrameworkCore;
using TaxFairy.Core.Contracts;
using TaxFairy.Core.Models;
using TaxFairy.Infrastructure.Data.Models;
using TaxFairy.Infrastructure.Repositories;

namespace TaxFairy.Core.Services
{
    public class PrivacyService : IPrivacyService
    {
        private readonly ITaxFairyDbRepository repo;


        public PrivacyService(ITaxFairyDbRepository _repo)
        {
            repo = _repo;
        }
        public async Task<PrivacyEditViewModel> GetPrivacy()
        {
            var privacy = await repo.All<PrivacyPolicy>()
                         .Select(p => new PrivacyEditViewModel()
                         {
                             Id = p.Id.ToString(),
                             Content = p.Content,
                             LastUpdated = p.LastUpdated

                         })
                         .FirstOrDefaultAsync();

            return privacy;
        }
    }
}
