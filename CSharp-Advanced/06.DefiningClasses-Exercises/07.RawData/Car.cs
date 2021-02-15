using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    class Car
    {


        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)

        {
            Model = model;
            Cargo = cargo;
            Engine = engine;
            Tires = tires;
        }


        public string Model { get; set; }

        public Cargo Cargo { get; set; }

        public Engine Engine { get; set; }

        public Tire[] Tires { get; set; }

       
    }
}
