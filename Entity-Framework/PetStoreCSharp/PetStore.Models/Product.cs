using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using PetStore.Common;

namespace PetStore.Models
{
    public class Product
    {
        public Product()
        {
            Id = Guid.NewGuid().ToString();
            AvailableStores = new HashSet<Store>();
            Sales = new HashSet<ProductSale>();
        }
        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(ProductValidationConstants.NAME_MAX_LENGTH)]
        public string Name { get; set; }
        [MaxLength(ProductValidationConstants.DESCRIPTION_MAX_LENGTH)]
        public string  Description { get; set; }
        public decimal  Price { get; set; }
        public int Quantity { get; set; }
        [Required]
        [MaxLength(ProductValidationConstants.DISTRIBUTOR_MAX_LENGTH)]
        public string DistributorName { get; set; }
        public bool InStock => this.Quantity > 0;

        [ForeignKey(nameof(ProductType))]
        public int ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }
        public ICollection<Store> AvailableStores { get; set; }
        public virtual ICollection<ProductSale> Sales { get; set; }

    }
}
