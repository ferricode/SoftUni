using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectingConstructors
{
    public class Student
    {


        private int averageGrade = 2;
        private static int age = 15;
        internal string FullName = "Pesho Peshov";
        public string priakor = "Gotinia";

        public Student()
        {

        }

        public Student(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}