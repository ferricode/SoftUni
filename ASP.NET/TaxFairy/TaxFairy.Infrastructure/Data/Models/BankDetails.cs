﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TaxFairy.Infrastructure.Data.Models
{
    using static DataConstants;
    public class BankDetails
    {
        [Key]
        [MaxLength(IdMaxLength)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(BankNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(IbanLength)]
        public string Iban { get; set; }

        [Required]
        [StringLength(BicLength)]
        public string Bic { get; set; }

    }
}