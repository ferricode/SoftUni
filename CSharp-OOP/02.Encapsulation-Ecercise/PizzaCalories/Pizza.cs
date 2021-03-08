using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int MaxToppingCount = 10;
        private const int MinNameLength = 1;
        private const int MaxNameLength = 15;


        private string name;
        private Dough dough;

        private List<Topping> toppings;
        public Pizza(string name, Dough dough)
        {
            Name = name;
            this.dough = dough;

            toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Length < MinNameLength || value.Length > MaxNameLength)
                {
                    throw new ArgumentException($"Pizza name should be between {MinNameLength} and {MaxNameLength} symbols.");
                }
                this.name = value;
            }
        }
        public void AddTopping(Topping topping)
        {
            if (toppings.Count == MaxToppingCount)
            {
                throw new InvalidOperationException($"Number of toppings should be in range [0..{MaxToppingCount}].");
            }

            toppings.Add(topping);
        }
        public double GetCalories()
        {
            return dough.GetCalories() + toppings.Sum(t => t.GetCalories());
        }


    }
}
