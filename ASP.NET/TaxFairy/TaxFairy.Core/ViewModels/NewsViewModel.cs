using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxFairy.Core.ViewModels
{
    public class NewsViewModel
    {

        public string Id { get; set; }

        [StringLength(10000, MinimumLength = 0, ErrorMessage = "Съдържанието трябва да бъде по-малко от {1} символа")]
        public string Content { get; set; }

        public DateTime IssueDate { get; set; }

    }
}
