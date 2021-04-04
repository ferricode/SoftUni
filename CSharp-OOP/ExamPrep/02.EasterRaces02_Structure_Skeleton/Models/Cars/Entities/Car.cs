using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int hoursePower;
    
        private int minHoursePower;
        private int maxHoursePower;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.minHoursePower = minHoursePower;
            this.maxHoursePower = maxHoursePower;

            Model = model;
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;

        }

        public string Model
        {
            get
            {
                return model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, model, 1));
                }
                model = value;
            }
        }
        public int HorsePower
        {
            get
            {
                return hoursePower;
            }
            private set
            {
                if (value < this.minHoursePower && value > this.maxHoursePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                hoursePower = value;

            }
        }
        public double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps)
        {
            return CubicCentimeters / HorsePower * laps;
        }
    }
}
