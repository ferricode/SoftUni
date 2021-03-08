using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private int MinToppingWight = 1;
        private int MaxToppingWeight = 50;
        private string name;
        private int weight;

        public Topping(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name
        {
            get => name;
            set
            {
                var valueAsLower = value.ToLower();
                if (valueAsLower != "meat" &&
                  valueAsLower != "veggies" &&
                  valueAsLower != "cheese" &&
                  valueAsLower != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                name = value;
            }
        }
        public int Weight
        {
            get => weight;
            set
            {
                if (value < MinToppingWight || value > MaxToppingWeight)
                {
                    throw new ArgumentException($"{Name} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }
        public double GetCalories()
        {
            var modifier = GetModifier();

            return Weight * 2 * modifier;
        }

        private double GetModifier()
        {
            var nameLower = name.ToLower();

            if (nameLower == "meat")
            {
                return 1.2;
            }
            else if (nameLower == "veggies")
            {
                return 0.8;
            }
            else if (nameLower == "cheese")
            {
                return 1.1;
            }
            return 0.9;
        }
    }
}
