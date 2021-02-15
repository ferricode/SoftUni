using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string line = Console.ReadLine();

            while (line!="end")
            {
                string[] token = line.Split();

                string firstName = token[0];
                string lastName = token[1];
                int age = int.Parse(token[2]);
                string city = token[3];

                Student student = new Student()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    City = city,
                };
                students.Add(student);
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
    }

}
