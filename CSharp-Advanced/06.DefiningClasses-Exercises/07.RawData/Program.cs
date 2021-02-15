using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
          
            int carsCount = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();


            while (carsCount != 0)
            {
                string[] inputLine = Console.ReadLine().Split();

                //"{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType} {tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age} {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"

                string model = inputLine[0];
                int engineSpeed = int.Parse(inputLine[1]);
                int enginePower = int.Parse(inputLine[2]);
                int cargoWeight = int.Parse(inputLine[3]);
                string cargoType = inputLine[4];
                double pressure1 = double.Parse(inputLine[5]);
                int age1 = int.Parse(inputLine[6]);
                double pressure2 = double.Parse(inputLine[7]);
                int age2 = int.Parse(inputLine[8]);
                double pressure3 = double.Parse(inputLine[9]);
                int age3 = int.Parse(inputLine[10]);
                double pressure4 = double.Parse(inputLine[11]);
                int age4 = int.Parse(inputLine[12]);

                Engine engine = new Engine(engineSpeed, enginePower);

                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Tire[] tires = new Tire[4]
                {
                new Tire(pressure1, age1),
                new Tire(pressure2, age2),
                new Tire(pressure3, age3),
                new Tire(pressure4, age4),
                };


                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
                carsCount--;
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                foreach (var car in cars)
                {
                    if (car.Cargo.CargoType == "fragile" && car.Tires.Any(t => t.Pressure < 1))
                    {

                        Console.WriteLine($"{car.Model}");

                    }
                }
            }
            else if (command == "flamable")
            {
                foreach (var car in cars.Where(c => c.Cargo.CargoType == "flamable")
                    .Where(c => c.Engine.EnginePower > 250))
                {
                    Console.WriteLine($"{car.Model}");
                }

            } 
        }
    }
}
