using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals.Felins
{
    public class Tiger : Feline
    {
        private const double BaseWeightModifier = 1.0;
        private static HashSet<string> tigerAllowedFood = new HashSet<string>
        {
            nameof(Meat),

        };
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, tigerAllowedFood, BaseWeightModifier, livingRegion, breed)
        {
        }
        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
