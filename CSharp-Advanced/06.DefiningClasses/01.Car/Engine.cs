using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Engine
    {
        public Engine(int horsePowe, double cubicCapacity)
        {
            HorsePower = horsePowe;
            CubicCapacity = cubicCapacity;
        }
        public int HorsePower { get; set; }
        public double CubicCapacity { get; set; }
    }
}
