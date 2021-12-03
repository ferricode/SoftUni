using System.Xml.Serialization;

namespace CarDealer.DTO.ExportDto
{
    [XmlType("part")]
    public class CartPartInfoDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }
       
    }
}