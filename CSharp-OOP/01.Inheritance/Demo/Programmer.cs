using System;
using System.Collections.Generic;
using System.Text;

namespace DemoInheritance
{
   public class Programmer:Employee,IPerson
    {
        public Programmer(string name)
          : base(name)
        {

        }
        public string Language { get; set; }
    }
}
