using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetStore.Models
{
    public class PetReservation
    {
        public PetReservation()
        {
            Id = Guid.NewGuid().ToString();
        }


        [Key]
        public string  Id { get; set; }

        [Required]
        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; }
        public virtual Client Client { get; set; }

        [Required]
        [ForeignKey(nameof(Pet))]
        public string PetId { get; set; }
        public virtual Pet Pet { get; set; }
        public DateTime ReserverdOn { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
