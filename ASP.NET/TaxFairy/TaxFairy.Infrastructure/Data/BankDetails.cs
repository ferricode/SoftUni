using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxFairy.Infrastructure.Data
{
    public class BankDetails
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(35)]
        public string Iban { get; set; }

        [Required]
        [StringLength(11)]
        public string Bic { get; set; }

    }
}
