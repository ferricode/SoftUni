using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models.Users
{
    public class CreatePlayersViewModel
    {

        [Required]
        [StringLength(80, MinimumLength = 5, ErrorMessage ="{0} must be between {2} and {1} characters.")]
        public string FullName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} characters.")]
        public string Position { get; set; }

        [Range(0, 10, ErrorMessage = "{0} must be between {1} and {2}.")]
        public byte Speed { get; set; }

        [Range(0, 10, ErrorMessage = "{0} must be between {1} and {2}.")]
        public byte Endurance { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "{0} must be maximum {1} characters.")]
        public string Description { get; set; }
       

    }
}
