using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using PetStore.Common;

namespace PetStore.Models
{
   public  class Service
    {
        public Service()
        {
            Id = Guid.NewGuid().ToString();
            Stores = new HashSet<Store>();
        }
        [Key]
        public string  Id { get; set; }

        [Required]
        [MaxLength(ServiceValidationConstants.NAME_MAX_LENGTH)]
        public string Name { get; set; }
        [MaxLength(ServiceValidationConstants.DESCRIPTION_MAX_LENGTH)]
        public string  Description { get; set; }
        public decimal Price { get; set; }
        public double Discount { get; set; }
        public virtual ICollection<Store> Stores { get; set; }

    }
}
