using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammals.Felins
{
    public abstract class Feline : Mammal
    {
        protected Feline(
            string name,
            double weight,
            HashSet<string> alowedFoods,
            double weightModifier,
            string livingRegion,
            string breed)
            : base(name, weight, alowedFoods, weightModifier, livingRegion)
        {
            Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
