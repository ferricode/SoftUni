using PetStore.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetStore.Models
{
    public class Breed
    {
        public Breed()
        {
            Pets = new HashSet<Pet>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(BreedValidationConstants.NAME_MAX_LENGTH)]
        public string Name { get; set; }
        public virtual ICollection<Pet> Pets{ get; set; }

    }
}
