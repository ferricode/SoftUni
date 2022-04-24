using PetStore.Common;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace PetStore.Models
{
    public class PetType
    {
        public PetType()
        {
            Pets = new HashSet<Pet>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(PetTypeValidationConstants.NAME_MAX_LENGTH)]
        public string  Name { get; set; }

        public virtual ICollection<Pet> Pets{ get; set; }
    }
}
