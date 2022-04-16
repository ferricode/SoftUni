using System.ComponentModel.DataAnnotations;


namespace TaxFairy.Infrastructure.Data.Models
{
    using static DataConstants;
    public class PrivacyPolicy
    {
        [Key]
        [MaxLength(IdMaxLength)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }

    }
}
