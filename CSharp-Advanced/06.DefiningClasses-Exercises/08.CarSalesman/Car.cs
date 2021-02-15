using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _08.CarSalesman
{
    public class Car
    {


        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }
        public Car(string model, Engine engine, int weight)
            : this(model, engine)
        {
            Weight = weight;
        }
        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            Color = color;
        }
        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine, weight)
        {
            Color = color;
        }

        public static Car CreateCar(string[] carInfo, Engine engine)
        {
            Car car = null;

            string model = carInfo[0];

            if (carInfo.Length == 2)
            {
                car = new Car(model, engine);

            }
            else if (carInfo.Length == 3)
            {
                if (char.IsDigit(carInfo[2][0]))
                {
                    int weight = int.Parse(carInfo[2]);

                    car = new Car(model, engine, weight);


                }
                else
                {
                    string color = carInfo[2];

                    car = new Car(model, engine, color);

                }


            }
            else if (carInfo.Length == 4)
            {
                int weight = int.Parse(carInfo[2]);
                string color = carInfo[3];

                car = new Car(model, engine, weight, color);

            }

            return car;

        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string weightStr = Weight == 0 || Weight == null ? "n/a" : Weight.ToString();
            string colorStr = String.IsNullOrEmpty(Color) ? "n/a" : Color;


            sb.AppendLine($"{Model}:")
               .AppendLine($"  {Engine}")
               .AppendLine($"  Weight: {weightStr}")
               .AppendLine($"  Color: {colorStr}");

            return sb.ToString().TrimEnd();
        }
    }


}
