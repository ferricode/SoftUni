﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Artillery.Data.Models
{
    public class Country
    {
        public Country()
        {
            CountriesGuns = new HashSet<CountryGun>();
        }
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string CountryName { get; set; }
        [Required]
        [Range(50000,10_000_000)]
        public int ArmySize { get; set; }
        public virtual ICollection<CountryGun> CountriesGuns { get; set; }

        /*•	Id – integer, Primary Key
•	CountryName – text with length [4, 60] (required)
•	ArmySize – integer in the range [50_000….10_000_000] (required)
•	CountriesGuns – a collection of CountryGun
*/
    }
}