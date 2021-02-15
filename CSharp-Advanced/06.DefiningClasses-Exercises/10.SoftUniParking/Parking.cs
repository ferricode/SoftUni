using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {

        private List<Car> cars;
        private int capacity;
        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new List<Car>();
        }
        public int Count => cars.Count;


        public string AddCar(Car car)
        {
            if (cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return $"Car with that registration number, already exists!";
            }
            if (cars.Count == capacity)
            {
                return $"Parking is full!";
            }
            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }
        public string RemoveCar(string registrationNumber)
        {
            Car car = cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);

            if (car == null)
            {
                return "Car with that registration number, doesn't exist!";
            }
            cars.Remove(car);
            return $"Successfully removed {registrationNumber}";

        }
        //public Car GetCar(string RegistrationNumber)
        //{
        //    Car car = this.cars.FirstOrDefault(c => c.RegistrationNumber == RegistrationNumber);

        //    return car;
        //}
        public Car GetCar(string registrationNumber) => cars
                                            .FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            this.cars = this.cars
                    .Where(c => !registrationNumbers.Contains(c.RegistrationNumber))
                    .ToList();
        }
    }
}
