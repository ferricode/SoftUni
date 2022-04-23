using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxFairy.Core.Contracts;
using TaxFairy.Core.ViewModels;
using TaxFairy.Infrastructure.Data.Identity;
using TaxFairy.Infrastructure.Data.Models;
using TaxFairy.Infrastructure.Repositories;

namespace TaxFairy.Core.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly ITaxFairyDbRepository repo;

        public InvoiceService(ITaxFairyDbRepository _repo)
        {
            repo = _repo;
        }
        public async Task<IEnumerable<InvoiceListViewModel>> GetInvoicesList(string id)
        {
        //    var vendor = await repo.GetByIdAsync<Vendor>(id);
        //    var invoiceList = await GetInvoices().Where(i=>i)


        //    return invoiceList;
        return null;

        }
        public async Task<IEnumerable<InvoiceListViewModel>> GetInvoices()
        {
            return await repo.All<Invoice>()
                    .Select(i => new InvoiceListViewModel
                    {
                        Id = i.Id.ToString(),
                        InvoiceNumber = i.InvoiceNumber,
                        InvoiceType = i.InvoiceType,
                        IssueDate = i.IssueDate,
                        TotalPrice = i.TotalPrice,
                        ContragentName = i.Contragent.Name
                    })
                    .ToListAsync();
        }
    }
}
