using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using PetStore.Common;

namespace PetStore.Models
{
    public class CardInfo
    {
        public CardInfo()
        {
            Id = Guid.NewGuid().ToString();
            ProductSales = new HashSet<ProductSale>();
          
        }
        public string  Id { get; set; }
        [Required]
        [MaxLength(CardInfoValidationConstants.CARD_NUMBER_MAX_LENGTH)]
        public string Number  { get; set; }
        [Required]
        [MaxLength(CardInfoValidationConstants.CARD_HOLDER_MAX_LENGTH)]
        public string HolderName  { get; set; }
        [Required]
        [MaxLength(CardInfoValidationConstants.EXPIRATION_DATE_MAX_LENGTH)]
        public string ExpirationDate  { get; set; }
        [Required]
        [MaxLength(CardInfoValidationConstants.CVC_MAX_LENGTH)]
        public string CVC { get; set; }

        [Required]
        [ForeignKey(nameof(ClientId))]
        public string  ClientId { get; set; }
        public virtual Client Owner { get; set; }
        public virtual ICollection<ProductSale> ProductSales { get; set; }

    }
}
