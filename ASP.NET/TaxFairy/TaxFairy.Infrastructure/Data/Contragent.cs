using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxFairy.Infrastructure.Data
{
    public class Contragent
    {

        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Identifier { get; set; }

        [Required]
        [StringLength(20)]
        public string? TaxIdentifier { get; set; }

        [StringLength(60)]
        public string? АccountablePerson { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }


        [StringLength(16)]
        public string? PhoneNumber { get; set; }

        [StringLength(50)]
        public string? Email { get; set; }
    }
}
