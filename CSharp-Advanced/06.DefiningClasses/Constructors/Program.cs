using System;

namespace Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Pesho");
            Console.WriteLine("Student in main!");
            Console.WriteLine(student.Name  );
        }
    }
}
