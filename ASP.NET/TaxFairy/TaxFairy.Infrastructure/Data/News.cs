using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxFairy.Infrastructure.Data
{
    public class News
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(5000)]
        public string Content { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }
    }
}
