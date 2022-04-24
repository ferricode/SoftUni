using System.ComponentModel.DataAnnotations;

namespace FootballManager.Data.Models
{
    public class User
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength =5)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(60, MinimumLength =10)]
        public string Email { get; set; }
        [Required]
        [StringLength(64)]
        public string Password { get; set; }
        public ICollection<UserPlayer> UserPlayers { get; set; }
        public User()
        {
            UserPlayers = new List<UserPlayer>();
            Id= Guid.NewGuid().ToString();
        }

    }
}
//•	Has an Id – a string, Primary Key
//•	Has a Username – a string with min length 5 and max length 20 (required)
//•	Has an Email – a string with min length 10 and max length 60 (required)
//•	Has a Password – a string with min length 5 and max length 20 (before hashed)  -no max length required for a hashed password in the database (required)
//•	Has UserPlayers collection
