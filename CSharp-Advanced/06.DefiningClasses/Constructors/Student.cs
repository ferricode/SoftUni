using System;
using System.Collections.Generic;
using System.Text;

namespace Constructors
{
    class Student
    {
        public Student(string name) 
        {
            Name = name;
            Console.WriteLine("Constructor called"); 
        }
        public string Name { get; set; }
    }
}
