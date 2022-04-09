using TaxFairy.Infrastructure.Data;
using TaxFairy.Infrastructure.Data.Common.Warehouse.Infrastructure.Data.Common;

namespace TaxFairy.Infrastructure.Repositories
{
    public class TaxFairyDbRepository:Repository, ITaxFairyDbRepository
    {
        public TaxFairyDbRepository(ApplicationDbContext context)
        {
            this.Context = context;

        }
    }
}
