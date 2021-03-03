using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const int MinWeigth = 1;
        private const int MaxWeigth = 200;
        private string flourType;
        private string bakingTechnique;
        private int weigth;

        private const string InvalidDoughExceptionMessage = "Invalid type of dough.";

        public Dough(string flourType, string bakingTechnique, int weigth)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weigth = weigth;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                var valueAsLower = value.ToLower();
                if (valueAsLower != "white" && valueAsLower != "whilegrain")
                {
                    throw new ArgumentException(InvalidDoughExceptionMessage);
                }
                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            set
            {
                var valueAsLower = value.ToLower();
                if (valueAsLower != "chewy" && valueAsLower != "crispy" && valueAsLower != "homemade")
                {
                    throw new ArgumentException(InvalidDoughExceptionMessage);
                }
                this.bakingTechnique = value;
            }

        }
        public int Weigth
        {
            get => this.weigth;
            private set
            {
                if (value<MinWeigth||value>MaxWeigth)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{MinWeigth}..{MaxWeigth}].");
                }
            }
        }
    }
}
