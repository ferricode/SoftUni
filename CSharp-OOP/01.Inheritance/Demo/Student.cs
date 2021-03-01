using System;
using System.Collections.Generic;
using System.Text;

namespace DemoInheritance
{
    public class Student:Person
    {
        private int veryImportantPrivateField;
        public Student(string name)
            : base(name)
        {
            this.veryImportantPrivateField = 42;
        }
        public Student(string name, string school)
            :this(name)
        {
            School = school;

        }
        //public Student()
        //    :base(string.Empty)
        //{

        //}
        
        public string School { get; set; }
    }
}
