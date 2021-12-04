using System.Xml.Serialization;

namespace ProductShop
{
    [XmlType("Product")]
    public class ExportProductInRangeDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]

        public decimal Price { get; set; }

        [XmlElement("buyer")]

        public string Buyer { get; set; }
    }
}