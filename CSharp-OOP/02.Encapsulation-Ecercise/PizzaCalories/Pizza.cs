using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int MinNameLength = 1;
        private const int MaxNameLength = 15;


        private string name;
        private Dough dough;
        public Pizza(string name, Dough dough)
        {
            Name = name;
            this.dough = dough;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Length < MinNameLength || value.Length > MaxNameLength)
                {
                    throw new ArgumentException($"Pizza name should be between {MinNameLength} and {MaxNameLength} symbols.")
                }
            }
        }

    }
}
