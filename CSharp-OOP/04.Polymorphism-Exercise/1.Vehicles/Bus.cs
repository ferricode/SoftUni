using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles
{
    public class Bus : Vehicle
    {
        private const double BusAirConditionModifier = 1.4;

        public Bus(double fuel, double fuelConsumption, double tankCapacity)
            : base(fuel, fuelConsumption, tankCapacity, BusAirConditionModifier)

        {
        }
        public void DriveEmpty(double distance)
        {
            double requiredFuel = FuelConsumption * distance;

            if (requiredFuel > Fuel)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }
            Fuel -= requiredFuel;
        }

       
    }
}
