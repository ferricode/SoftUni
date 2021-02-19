using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data = new List<Car>();

        public Parking(string type, int capacity)
        {
            this.data = new List<Car>();
            Type = type;
            Capacity = capacity;
        }

        public string Type { get; set; }

        public int Capacity { get; set; }
        public int Count { get { return data.Count; } }

        public void Add(Car car)
        {
            if (data.Count < Capacity)
            {
                data.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            Car currCar = data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
            if (data.Contains(currCar))
            {
                data.Remove(currCar);
                return true;
            }
            else
            {
                return false;
            }

        }
        public Car GetLatestCar()
        {
            if (data.Count>0)
            {
              return data.OrderByDescending(c => c.Year).First();
             
            }
            return null;
        }
        public Car GetCar(string manufacturer, string model)
        {
            Car currCar = data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
            if (data.Contains(currCar))
            {

                return currCar;
            }
            else
            {
                return null;
            }
        }
        public string GetStatistics()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"The cars are parked in {Type}:");

            foreach (var car in data)
            {
                result.AppendLine(car.ToString());
            }
            return result.ToString().Trim();
        }
    }
}
