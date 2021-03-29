using System;
using System.Reflection;

namespace CreateInstanceConstructors
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();


            Type studentType = typeof(Student);
            FieldInfo[] fields = studentType.GetFields(
                BindingFlags.Instance | 
                BindingFlags.NonPublic | 
                BindingFlags.Public |
                BindingFlags.Static);

            foreach (var field in fields)
            {
                Console.WriteLine(field.Name);
                Console.WriteLine(field.FieldType);
                Console.WriteLine(field.IsPublic);
                Console.WriteLine();

                Console.WriteLine("Accesing private data average grade");

                var grade = field.GetValue(student);

                Console.WriteLine($"{field.NAme} : {field.va}");
            }
        }
    }
}
