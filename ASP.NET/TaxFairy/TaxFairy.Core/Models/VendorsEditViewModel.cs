using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxFairy.Core.Models
{
    public class VendorsEditViewModel
    {



        public string Name { get; set; }

        public string Identifier { get; set; }

        public string? TaxIdentifier { get; set; }

        public string АccountablePerson { get; set; }

        public string Address { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public List<BankDetailsEditViewModel> BankDetails
        {
            get; set;
        }
    }
}