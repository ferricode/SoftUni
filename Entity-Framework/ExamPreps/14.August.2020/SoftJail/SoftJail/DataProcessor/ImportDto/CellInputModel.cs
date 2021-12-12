﻿using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class CellInputModel
    {
       
        [Required]
        //[StringLength(1000, MinimumLength =1)]
        [Range(1,1000)]
        public int CellNumber { get; set; }
        [Required]
        public bool HasWindow { get; set; }

     
    }
}