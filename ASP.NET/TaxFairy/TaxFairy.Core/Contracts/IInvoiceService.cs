using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxFairy.Core.ViewModels;

namespace TaxFairy.Core.Contracts
{
    public interface IInvoiceService
    {
        Task<IEnumerable<InvoiceListViewModel>> GetInvoices();
    }
}
