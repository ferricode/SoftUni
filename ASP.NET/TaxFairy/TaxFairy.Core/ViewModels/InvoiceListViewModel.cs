using TaxFairy.Infrastructure.Data.Enums;

namespace TaxFairy.Core.ViewModels
{
    public class InvoiceListViewModel
    {
        public string Id { get; set; }
        public long InvoiceNumber { get; set; }

        public InvoiceType InvoiceType { get; set; }

        public DateTime IssueDate { get; set; }

        public decimal TotalPrice { get; set; }

        public string ContragentName { get; set; }

    }
}
