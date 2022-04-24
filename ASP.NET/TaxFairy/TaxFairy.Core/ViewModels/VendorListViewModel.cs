using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxFairy.Core.ViewModels
{
    public class VendorListViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Identifier { get; set; }
        public string AccountablePerson { get; set; }

        public string? TaxIdentifier { get; set; }

      }
}
