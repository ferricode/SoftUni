using System.ComponentModel.DataAnnotations;

namespace FootballManager.Data.Models
{
    public class Player
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(80, MinimumLength =5)]
        public string FullName { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [StringLength(20, MinimumLength = 5)]
        public string Position { get; set; }
        [Range(0,10)]
        public byte Speed { get; set; }
        [Range(0, 10)]
        public byte Endurance { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        public ICollection<UserPlayer> UserPlayers { get; set; }
        public Player()
        {
             UserPlayers = new List<UserPlayer>();
        }
    }
}
//•	Has Id – an int, Primary Key
//•	Has FullName – a string (required); min.length: 5, max.length: 80
//•	Has ImageUrl – a string (required)
//•	Has Position – a string (required); min.length: 5, max.length: 20
//•	Has Speed – a byte (required); cannot be negative or bigger than 10
//•	Has Endurance – a byte (required); cannot be negative or bigger than 10
//•	Has a Description – a string with max length 200 (required)
//•	Has UserPlayers collection
