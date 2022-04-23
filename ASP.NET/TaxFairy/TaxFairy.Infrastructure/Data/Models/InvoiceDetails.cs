using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaxFairy.Infrastructure.Data.Enums;

namespace TaxFairy.Infrastructure.Data.Models
{
    using static DataConstants;
    public class InvoiceDetails
    {
        [Key]
        [MaxLength(IdMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(200)]
        public string ItemName { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Required]
        public int Quantity{ get; set; }

        [Required]
        public TaxPercentage TaxPercentage { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }


    }
}
