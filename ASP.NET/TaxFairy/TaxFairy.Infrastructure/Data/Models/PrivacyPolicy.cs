using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxFairy.Infrastructure.Data.Models
{
    using static DataConstants;
    public class PrivacyPolicy
    {
        [Key]
        [MaxLength(IdMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(ContentMax)]
        public string Content { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime LastUpdated { get; set; }

    }
}
