using System;

namespace StaticClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            SoftuniMaths math = new SoftuniMaths();

            math.PI = 3;

            SoftuniMaths.Add(5, 4);
            math.Multiply(5, 4);


        }
    }
}
