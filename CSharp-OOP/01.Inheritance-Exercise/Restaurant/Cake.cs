using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const decimal DefaultPrice = 5;
        private const double DefaultGrams = 250;
        private const double DefaultCalories= 1000;


        public Cake(string name, decimal price, double grams, double calories) 
            : base(name, DefaultPrice,DefaultGrams, DefaultCalories)
        {
        }
    }
}
