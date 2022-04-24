using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using PetStore.Common;

namespace PetStore.Models
{
    public class Store
    {
        public Store()
        {
            Id = Guid.NewGuid().ToString();
            Pets = new HashSet<Pet>();
            Products = new HashSet<Product>();
            Services = new HashSet<Service>();
           
        }
        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(StoreValidationConstants.NAME_MAX_LENGTH)]
        public string Name { get; set; }
        [MaxLength(StoreValidationConstants.DESCRIPTION_MAX_LENGTH)]
        public string Description { get; set; }

        [MaxLength(StoreValidationConstants.TIME_MAX_LENGTH)]
        public string WorkTime { get; set; }

        [MaxLength(StoreValidationConstants.EMAIL_MAX_LENGTH)]
        public string Email { get; set; }

        [Required]
        [MaxLength(StoreValidationConstants.PHONENUMBER_MAX_LENGTH)]
        public string PhoneNumber { get; set; }

        [Required]
        [ForeignKey(nameof(Address))]
        public string AddressId { get; set; }
        public virtual Address Address { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Service> Services { get; set; }
      


    }
}
