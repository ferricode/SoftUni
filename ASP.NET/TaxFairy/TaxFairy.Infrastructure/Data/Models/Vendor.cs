using System.ComponentModel.DataAnnotations;

namespace TaxFairy.Infrastructure.Data.Models
{
    using static DataConstants;
    public class Vendor
    {
        [Key]
        [MaxLength(IdMaxLength)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(NameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(IdentifierLength)]
        public string Identifier { get; set; }

        [Required]
        [StringLength(TaxIdentifierLength)]
        public string? TaxIdentifier { get; set; }

        [Required]
        [StringLength(AccountablePersonLength)]
        public string АccountablePerson { get; set; }

        [Required]
        [StringLength(AddressLength)]
        public string Address { get; set; }


        [StringLength(PhoneNumberLength)]
        public string? PhoneNumber { get; set; }

        [StringLength(EmailLength)]
        public string? Email { get; set; }

        public IList<BankDetails> BankDetails { get; set; } = new List<BankDetails>();
        public IList<Invoice> Invoices { get; set; } = new List<Invoice>();



    }
}
