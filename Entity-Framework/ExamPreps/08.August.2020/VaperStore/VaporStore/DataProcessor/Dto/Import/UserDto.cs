using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.DataProcessor.Dto.Import
{
   public  class UserDto
    {
       
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Username { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$")]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }

        [Range(3, 103)]
        public int Age { get; set; }

        [MinLength(1)]
        public CardDto[] Cards { get; set; }

        /*•	Id – integer, Primary Key
•	Username – text with length [3, 20] (required)
•	FullName – text, which has two words, consisting of Latin letters. Both start with an upper letter and are followed by lower letters. The two words are separated by a single space (ex. "John Smith") (required)
•	Email – text (required)
•	Age – integer in the range [3, 103] (required)
•	Cards – collection of type Card
*/
    }
}
