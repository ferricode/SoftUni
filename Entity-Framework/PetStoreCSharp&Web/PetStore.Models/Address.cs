using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using PetStore.Common;
namespace PetStore.Models
{
    public class Address
    {
        public Address()
        {
            Id = Guid.NewGuid().ToString();
            Clients = new HashSet<Client>();
            Stores = new HashSet<Store>();
            Sales = new HashSet<ProductSale>();
        }
        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(AddressValidationConstants.TOWN_NAME_MACX_LENGTH)]
        public string  TownName { get; set; }

        [Required]
        [MaxLength(AddressValidationConstants.ADDRESS_TEXT_MAX_LENGTH)]
        public string AddressText { get; set; }

        [MaxLength(AddressValidationConstants.NOTES_TEXT_MAX_LENGTH)]
        public string  Notes { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public ICollection<ProductSale> Sales { get; set; }

    }
}
