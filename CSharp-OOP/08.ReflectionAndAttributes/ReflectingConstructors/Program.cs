using System;
using System.Reflection;

namespace ReflectingConstructors
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Student);

            ConstructorInfo[] concreteConstructor = type.GetConstructor(new Type[] {typeof(string), typeof(String)});
            ConstructorInfo[] constructors = type.GetConstructors();

            foreach (var constructor in constructors)
            {

            }
        }
    }
}
