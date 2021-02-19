using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {

        private List<Student> students { get; set; }

        
        public Classroom(int capacity)
        {
            students = new List<Student>();
            Capacity = capacity;
        }
        public int Capacity { get; set; }
        public int Count { get { return students.Count; } }

        public string RegisterStudent(Student student)
        {
            if (students.Count < Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }
        public string DismissStudent(string firstName, string lastName)
        {
            Student student = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

            if (student != null)
            {
                students.Remove(student);
                return $"Dismissed student {firstName} {lastName}";
            }
            else
            {
                return "Student not found";
            }

        }
        public string GetSubjectInfo(string subject)
        {
            StringBuilder sb = new StringBuilder();

            Student currentStudent = students.FirstOrDefault(s => s.Subject == subject);

            if (currentStudent != null)
            {
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine($"Students:");
                foreach (var student in students.Where(s => s.Subject == subject))
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }
            }
            else
            {
                sb.AppendLine("No students enrolled for the subject");
            }
            return sb.ToString().Trim();
        }
        public int GetStudentsCount()
        {
            return students.Count();
        }

        public string GetStudent(string firstName, string lastName)
        {
            Student student = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
            return student.ToString();
        }
    }
}
