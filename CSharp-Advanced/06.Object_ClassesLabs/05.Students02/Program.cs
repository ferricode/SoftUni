using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Students02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();


            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] token = line.Split();

                string firstName = token[0];
                string lastName = token[1];
                int age = int.Parse(token[2]);
                string city = token[3];


                if (IsStudentExisting(students, firstName, lastName))
                {
                    Student student = GetStudent(students, firstName, lastName);

                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.City = city;
                }
                else
                {
                    Student student = new Student()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        City = city

                    };
                    students.Add(student);
                }

                line = Console.ReadLine();
            }

            string filterCity = Console.ReadLine();

            List<Student> filteredStudents = students
                                            .Where(s => s.City == filterCity)
                                            .ToList();
            foreach (Student student in filteredStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is { student.Age } years old.");
            }

        }

        private static Student GetStudent(List<Student> students, string firstName, string lastName)
        {
            Student existingStudent = null;
            foreach (Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    existingStudent = student;
                }
            }
            return existingStudent;
        }

        static bool IsStudentExisting(List<Student> students, string firstName, string lastName)
        {
            foreach (Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }

            }
            return false;
        }
    }
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public string City { get; set; }
    }
}
