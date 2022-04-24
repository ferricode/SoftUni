using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace JsonDemo
{
    public class Name
    {
        [XmlAttribute("firstName")]
        public string  FirstName { get; set; }

        [XmlAttribute("lastName")]
        public string  LastName { get; set; }
    }
}
