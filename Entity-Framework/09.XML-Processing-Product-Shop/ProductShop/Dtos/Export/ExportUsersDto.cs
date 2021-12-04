using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("User")]
    public class ExportUsersDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }
        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlArray("soldProducts")]
        public ProductSoldDTO[] SoldProducts { get; set; }
    }
}
