using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 200;
        private string flourType;
        private string bakingTechnique;
        private int weight;

        private const string InvalidDoughExceptionMessage = "Invalid type of dough.";

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                var valueAsLower = value.ToLower();
                if (valueAsLower != "white" && valueAsLower != "wholegrain")
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
        public int Weight
        {
            get => this.weight;
            private set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");
                }

                this.weight = value;
            }
        }
        public double GetCalories()
        {
            var flourTypeModifier = GetFlourTypeModifier();
            var bakingTechniqueModifier = GetBackingTechniqueModifier();
            return Weight * 2 * flourTypeModifier * bakingTechniqueModifier;
        }

        private double GetBackingTechniqueModifier()
        {
            var bakingTechniqueLower = bakingTechnique.ToLower();
            if (bakingTechniqueLower == "crispy")
            {
                return 0.9;
            }
            else if (bakingTechniqueLower == "chewy")
            {
                return 1.1;
            }

            return 1.0;
        }

        private double GetFlourTypeModifier()
        {
            var flourTypeLower = flourType.ToLower();
            if (flourTypeLower == "white")
            {
                return 1.5;
            }
            return 1.0;
        }
    }
}
