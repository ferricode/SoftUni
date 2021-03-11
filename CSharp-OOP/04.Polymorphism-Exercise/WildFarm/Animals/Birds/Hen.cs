using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Hen : Bird
    {

        private const double BaseWeightModifier = 0.35;

        private static HashSet<string> henlAllowedFoods = new HashSet<string>
        {
        nameof(Meat),
        nameof(Vegetable),
        nameof(Fruit),
        nameof(Seeds)
        };
        public Hen(string name, double weight, double wingSize)
        : base(name, weight, henlAllowedFoods, BaseWeightModifier, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
