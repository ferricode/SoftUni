using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaxFairy.Infrastructure.Data.Enums;

namespace TaxFairy.Infrastructure.Data.Models
{
    using static DataConstants;
    public class Invoice
    {
        [Key]
        [MaxLength(IdMaxLength)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Range(InvoiceNumberMin, InvoiceNumberMax)]
        public long InvoiceNumber { get; set; }

        [Required]
        public InvoiceType InvoiceType { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }


        [Required]
        public decimal NetPrice { get; set; }

        [Required]
        public decimal TotalTax { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        public Vendor Vendor { get; set; }

        [Required]
        public PaymentType PaymentType { get; set; }

        [ForeignKey(nameof(ContragentId))]
        public Contragent Contragent { get; set; }
        public Guid ContragentId { get; set; }
        public IList<InvoiceDetails> InvoiceDetails { get; set; } = new List<InvoiceDetails>();


    }
}
