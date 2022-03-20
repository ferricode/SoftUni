using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxFairy.Infrastructure.Data
{
    public class InvoiceDetails
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(200)]
        public string ItemName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity{ get; set; }
        [Required]
        public decimal TaxPercentage { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }


    }
}
