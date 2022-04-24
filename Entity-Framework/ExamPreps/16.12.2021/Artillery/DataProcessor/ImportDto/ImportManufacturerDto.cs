﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Manufacturer")]
    public class ImportManufacturerDto
    {
        [XmlElement("ManufacturerName")]
        [StringLength(40, MinimumLength = 4)]
        public string ManufacturerName { get; set; }

        [XmlElement("Founded")]
        [StringLength(100, MinimumLength =10)]
        public string Founded { get; set; }
    }
}
