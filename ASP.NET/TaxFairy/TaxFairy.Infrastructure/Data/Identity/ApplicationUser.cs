using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxFairy.Infrastructure.Data.Models;

namespace TaxFairy.Infrastructure.Data.Identity
{
    public class ApplicationUser:IdentityUser
    {
        [StringLength(60, MinimumLength =5)]
        public string? FullName { get; set; }
        public IList<Vendor> Vendors { get; set; }
        public ApplicationUser()
        {
            Vendors = new List<Vendor>();
        }
    }
}
