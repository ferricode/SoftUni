using System.ComponentModel.DataAnnotations;
using TaxFairy.Infrastructure.Data.Enums;

namespace TaxFairy.Infrastructure.Data.Models
{
    using static DataConstants;
    public class InvoiceDetails
    {
        [Key]
        [MaxLength(IdMaxLength)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(200)]
        public string ItemName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity{ get; set; }

        [Required]
        public TaxPercentage TaxPercentage { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }


    }
}
