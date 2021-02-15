﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    public class Engine
    {

        public string Model { get; set; }

        public int Power { get; set; }

        public int Displacement { get; set; }

        public string Efficiency { get; set; }

        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
        }
        public Engine(string model, int power, int displacement)
            : this(model, power)
        {
            Displacement = displacement;
        }
        public Engine(string model, int power, string efficiency)
            : this(model, power)
        {
            Efficiency = efficiency;
        }
        public Engine(string model, int power, int displacement, string efficiency)
            : this(model, power, displacement)
        {
            Efficiency = efficiency;
        }

        public static Engine CreateEngine(string[] engineInfo)
        {
            Engine engine = null;

            string model = engineInfo[0];
            int power = int.Parse(engineInfo[1]);

            if (engineInfo.Length == 2)
            {
                engine = new Engine(model, power);

            }
            else if (engineInfo.Length == 3)
            {
                if (char.IsDigit(engineInfo[2][0]))
                {
                    int displacement = int.Parse(engineInfo[2]);

                    engine = new Engine(model, power, displacement);


                }
                else
                {
                    string efficiency = engineInfo[2];

                    engine = new Engine(model, power, efficiency);

                }

            }
            else if (engineInfo.Length == 4)
            {
                int displacement = int.Parse(engineInfo[2]);
                string efficiency = engineInfo[3];

                engine = new Engine(model, power, displacement, efficiency);

            }
            return engine;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string displacementStr = Displacement == 0 || Displacement == null ? "n/a" : Displacement.ToString();
            string efficiencyStr = String.IsNullOrEmpty(Efficiency) ? "n/a" : Efficiency;


            sb.AppendLine($"{Model}:")
                .AppendLine($"    Power: {Power}")
                .AppendLine($"    Displacement: {displacementStr}")
                .AppendLine($"    Efficiency: {efficiencyStr}");

            return sb.ToString().TrimEnd(); 
        }

    }
}

