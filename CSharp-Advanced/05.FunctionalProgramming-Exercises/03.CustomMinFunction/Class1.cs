using System;
using System.Collections.Generic;
using System.Text;

namespace _03.CustomMinFunction
{
    static class Class1
    {
        public static int MyMin(this IEnumerable<int> source)
        {
            int minValue = int.MaxValue;
            foreach (var item in source)
            {
                if (item < minValue)
                {
                    minValue = item;
                }
            }
            return minValue;
        }
    }
}
