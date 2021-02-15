using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
       
        public string Make { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public string RegistrationNumber { get; set; }

        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            Make = make;
            Model = model;
            HorsePower = horsePower;
            RegistrationNumber = registrationNumber;
        }
        public override string ToString()
        {
            StringBuilder res = new StringBuilder();

            res.AppendLine($"Make: {this.Make}" + Environment.NewLine)
                .AppendLine($"Model: {this.Model}" + Environment.NewLine)
                .AppendLine($"HorsePower: {this.HorsePower}" + Environment.NewLine)
                 .AppendLine($"RegistrationNumber: {this.RegistrationNumber}" + Environment.NewLine);
           
            return res.ToString().TrimEnd();
        }


    }
}
