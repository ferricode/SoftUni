using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals
{
    public abstract class Bird : Animal
    {
       
        protected Bird(string name, double weight, HashSet<string> alowedFoods, double weightModifier, double wingSize)
            : base(name, weight, alowedFoods, weightModifier)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; set; }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, { WingSize}, {Weight}, { FoodEaten}]";
        }
    }
}
