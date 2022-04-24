using System;
using System.Collections.Generic;
using System.Text;

namespace Artillery.DataProcessor.ExportDto
{
   
   public class ShellDto
    {

        public double ShellWeight { get; set; }
        public string Caliber { get; set; }
        public virtual GunDto[] Guns { get; set; }
    }
}
