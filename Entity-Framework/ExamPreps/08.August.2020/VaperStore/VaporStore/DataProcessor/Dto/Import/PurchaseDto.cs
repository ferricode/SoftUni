using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class PurchaseDto
    {
     

        [Required]
        [XmlElement("Type")]
        public string Type { get; set; }

        [Required]
        [XmlElement("Key")]
        [RegularExpression(@"^(([A-Z0-9]{4}-){2})([A-Z0-9]{4})$")]
        public string Key { get; set; }

        [Required]
        [XmlElement("Date")]
        public string Date { get; set; }

        [Required]
        [XmlElement("Card")]
        public string Card { get; set; }

        [Required]
        [XmlAttribute("title")]
        public string Title { get; set; }
    }
}
