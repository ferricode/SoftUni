using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxFairy.Core.Contracts;
using TaxFairy.Core.Models;
using TaxFairy.Infrastructure.Data.Identity;
using TaxFairy.Infrastructure.Data.Models;
using TaxFairy.Infrastructure.Repositories;

namespace TaxFairy.Core.Services
{
    public class InvoiceService:IInvoiceService
    {
        private readonly ITaxFairyDbRepository repo;

        public InvoiceService(ITaxFairyDbRepository _repo)
        {
            repo = _repo;
        }
        public async Task<IEnumerable<InvoiceListViewModel>> GetInvoicesList(string id)
        {
            /* var user= await repo.GetByIdAsync<ApplicationUser>(id);
             var invoiceList = repo.All<ApplicationUser>()
                 .Where(u => u.Id == id)
                 .Include(u => u.Vendors)
                 .ThenInclude(c => c.Invoices)
                 .FirstOrDefault(); */
            return null;
           
        }
    }
}
