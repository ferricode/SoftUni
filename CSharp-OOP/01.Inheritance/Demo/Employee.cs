using System;
using System.Collections.Generic;
using System.Text;

namespace DemoInheritance
{
    public class Employee : Person
    {
        public Employee(string name)
           : base(name)
        {

        }
        public string Company { get; set; }
    }
}
