using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public abstract class Animal
    {

        protected Animal(string name, double weight, HashSet<string> alowedFoods, double weightModifier)
        {
            Name = name;
            Weight = weight;
 
            AlowedFoods = alowedFoods;
            WeightModifier = weightModifier;
        }
        private HashSet<string> AlowedFoods { get; set; }

        private double WeightModifier { get; set; }

     

        public string  Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        public abstract string ProduceSound();

        public void Eat(Food food)
        {
            if (!AlowedFoods.Contains(food.GetType().Name))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
            FoodEaten += food.Quantity;
            Weight += WeightModifier * food.Quantity;
        //1.Validate the food;
        //2.Increase.FoodEaten
        //3.Increase Weight
        }
    }
}
