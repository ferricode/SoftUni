﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Country")]
   public class ImportCountryDto
    {
        [XmlElement("CountryName")]
        [StringLength(60, MinimumLength =4)]
        public string CountryName { get; set; }

        [XmlElement("ArmySize")]
        [Range(50000, 10_000_000)]
        public int ArmySize { get; set; }

    }
}
