using System;
using System.Linq;
using System.Reflection;

namespace ReflectingMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(MathsSoftuni);

            MethodInfo[] methods = type.GetMethods(BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.Static);

            foreach (var method in methods)
            {
                ParameterInfo[] methodParamInfos = method.GetParameters();
                var methodParams=methodParamInfos.Select(p=>)
            }
        }
    }
}
