using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public List<Ingredient> Ingredients;

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new List<Ingredient>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }

        public void Add(Ingredient ingredient)
        {
            Ingredient isExist = Ingredients.FirstOrDefault(i => i.Name == ingredient.Name);

            if (Capacity < Ingredients.Count && isExist == null)
            {
                Ingredients.Add(ingredient);
            }
        }
        public bool Remove(string name)
        {

            Ingredient ingredientToremove = Ingredients.FirstOrDefault(i => i.Name == name);
            if (ingredientToremove != null)
            {
                Ingredients.Remove(ingredientToremove);
                return true;
            }
            return false;
        }
        public Ingredient FindIngredient(string name)
        {
            Ingredient ingredient = Ingredients.FirstOrDefault(i => i.Name == name);

            if (ingredient != null)
            {
                return ingredient;
            }
            return null;
        }
        public Ingredient GetMostAlcoholicIngredient()
        {
            Ingredient ingredient = Ingredients.OrderByDescending(i => i.Alcohol).First();
            return ingredient;

        }
        public int CurrentAlcoholLevel => Ingredients.Sum(i => i.Alcohol);

        //int alcoholSum = ;

        //foreach (var item in Ingredients)
        //{
        //    alcoholSum += item.Alcohol;
        //}
        //return alcoholSum;

        public string Report()
        {


            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: { CurrentAlcoholLevel}");

            foreach (var item in Ingredients)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();


        }
    }
}
