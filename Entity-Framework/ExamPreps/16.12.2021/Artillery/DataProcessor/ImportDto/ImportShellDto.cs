﻿

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Shell")]
    public class ImportShellDto
    {

        [XmlElement("ShellWeight")]
        [Range(2, 1680)]
        public double ShellWeight { get; set; }

        [XmlElement("Caliber")]
        [StringLength(30, MinimumLength =4)]
        public string Caliber { get; set; }


        /*•	Id – integer, Primary Key
•	ShellWeight – double in range  [2…1_680] (required)
•	Caliber – text with length [4…30] (required)
•	Guns – a collection of Gun
*/
    }
}
