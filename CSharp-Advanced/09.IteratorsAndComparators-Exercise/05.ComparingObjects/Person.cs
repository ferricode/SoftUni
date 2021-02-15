using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _05.ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)//5.string city)
        {
            Name = name;
            Age = age;
            //5. City = city;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            Person person = obj as Person;
            if (person.Name == this.Name && person.Age == this.Age)
            {
                return true;
            }
            return false;
        }
        public int CompareTo(Person other)
        {


            if (this.Name.CompareTo(other.Name) != 0)
            {
                return this.Name.CompareTo(other.Name);
            }

            return this.Age.CompareTo(other.Age);


            //5. 
            //public string  City { get; set; }

            //5.
            //public int CompareTo(Person other)
            //{


            //    if (this.Name.CompareTo(other.Name) != 0)
            //    {
            //        return this.Name.CompareTo(other.Name);
            //    }
            //    if (this.Age.CompareTo(other.Age) != 0)
            //    {
            //        return this.Age.CompareTo(other.Age);
            //    }
            //    return this.City.CompareTo(other.City);
            //}
        }
    }
}
