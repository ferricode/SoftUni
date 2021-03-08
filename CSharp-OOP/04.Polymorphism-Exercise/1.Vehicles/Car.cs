using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles
{
    public class Car : Vehicle
    {
        private const double CarAirConditionerModifier = 0.9;
        public Car(double fuel, double fuelConsumption, double tankCapacity)
            : base(fuel, fuelConsumption,tankCapacity, CarAirConditionerModifier)
        {
        }

    }
}
