using System.ComponentModel.DataAnnotations;

namespace TaxFairy.Core.ViewModels
{
    public class VendorEditViewModel
    {

        public string Id { get; set; }

        [Required]
        [StringLength(Infrastructure.Data.DataConstants.NameLength)]
        [Display(Name ="Тук въведи име на фирма")]
        public string Name { get; set; }

        [Required]
        [StringLength(Infrastructure.Data.DataConstants.IdentifierLength, ErrorMessage = "Дължината на ЕИК не трябва да е повече от 20 символа.")]
        //[StringLength(Infrastructure.Data.DataConstants.IdentifierLength)]
        public string Identifier { get; set; }

        [Required]
        [StringLength(Infrastructure.Data.DataConstants.TaxIdentifierLength)]
        public string? TaxIdentifier { get; set; }

        [Required]
        [StringLength(Infrastructure.Data.DataConstants.AccountablePersonLength)]
        public string АccountablePerson { get; set; }

        [Required]
        [StringLength(Infrastructure.Data.DataConstants.AddressLength)]
        public string Address { get; set; }


        [StringLength(Infrastructure.Data.DataConstants.PhoneNumberLength)]
        public string? PhoneNumber { get; set; }

        [StringLength(Infrastructure.Data.DataConstants.EmailLength)]
        public string? Email { get; set; }

    }
}