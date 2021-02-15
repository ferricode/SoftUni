using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int engCount = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < engCount; i++)
            {
                string[] enginInfo = Console.ReadLine().Split();
                Engine engine = Engine.CreateEngine(enginInfo);

                if (engine != null)
                {
                    engines.Add(engine);
                }


            }

            int carsCount = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            while (carsCount != 0)
            {
                string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Engine engine = engines.First(c => c.Model == carInfo[1]);

                Car car = Car.CreateCar(carInfo, engine);

                if (car != null)
                {
                    cars.Add(car);
                }
                
                carsCount--;
            }
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }

        }
    }
}
