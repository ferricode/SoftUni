﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
    
   public class ImportTheatreDto
    {
    
        [Required]
        [StringLength(30, MinimumLength =4)]
        public string Name { get; set; }
        [Required]
        [Range(1,10)]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [StringLength(30, MinimumLength =4)]
        public string Director { get; set; }

        public List<TicketsDto> Tickets { get; set; }

       
    }
}
