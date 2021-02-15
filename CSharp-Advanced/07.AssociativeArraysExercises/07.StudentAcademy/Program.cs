using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            for (int i = 0; i < rows * 2; i += 2)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double>());
                }
                students[name].Add(grade);
            }

            foreach (var student in students.OrderByDescending(v => v.Value.Average()))
            {
                if (student.Value.Average() >= 4.50)
                {
                    Console.WriteLine($"{student.Key} -> {student.Value.Average():f2}");
                }
            }


        }
    }
}
