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
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [Range(InvoiceNumberMin, InvoiceNumberMax)]
        public long InvoiceNumber { get; set; }

        [Required]
        public InvoiceType InvoiceType { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime IssueDate { get; set; }


        [Required]
        [Column(TypeName = "money")]
        public decimal NetPrice { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal TotalTax { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }

        public Vendor Vendor { get; set; }

        [Required]
        public PaymentType PaymentType { get; set; }

        [ForeignKey(nameof(ContragentId))]
        public Contragent Contragent { get; set; }
        public string ContragentId { get; set; }
        public IList<InvoiceDetails> InvoiceDetails { get; set; } = new List<InvoiceDetails>();


    }
}
