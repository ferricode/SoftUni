using PetStore.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetStore.Models
{
    public class ProductType
    {
        public ProductType()
        {
            Products = new HashSet<Product>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ProductTypeValidationConstants.NAME_MAX_LENGTH)]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
