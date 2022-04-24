using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
   public class ImportCountryGunDto
    {
        [Required]
        public int Id { get; set; }

    }
}
