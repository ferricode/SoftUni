using System;
using System.Collections.Generic;
using System.Text;

namespace DemoInheritance
{
    public class Person
    {
        public Person(string name)
        {
            Name = name;
        }

        private int age;
        public string Name { get; set; }
        public string Adress { get; set; }
        protected void GetOlder()
        {
            this.age++;
        }
    }
}
