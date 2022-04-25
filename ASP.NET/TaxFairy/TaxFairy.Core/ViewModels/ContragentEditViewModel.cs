using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxFairy.Core.ViewModels
{
    public class ContragentEditViewModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(Infrastructure.Data.DataConstants.NameLength)]
       
        public string Name { get; set; }

        [Required]
        [StringLength(Infrastructure.Data.DataConstants.IdentifierLength)]
      
        public string Identifier { get; set; }

        [Required]
        [StringLength(Infrastructure.Data.DataConstants.TaxIdentifierLength)]
        public string? TaxIdentifier { get; set; }

        [Required]
        [StringLength(Infrastructure.Data.DataConstants.AccountablePersonLength)]
        public string AccountablePerson { get; set; }

        [Required]
        [StringLength(Infrastructure.Data.DataConstants.AddressLength)]
        public string Address { get; set; }


        [StringLength(Infrastructure.Data.DataConstants.PhoneNumberLength)]
        public string? PhoneNumber { get; set; }

        [StringLength(Infrastructure.Data.DataConstants.EmailLength)]
        public string? Email { get; set; }
    }
}
