using System;
using System.Collections.Generic;
using System.Text;

namespace _03.TemplatePattern
{
    public class Sourdough : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for Sourdough Bread!");
        }
        public override void Bake()
        {
            Console.WriteLine("Baking the Sourdough bread, (20 minutes)");
        }


    }
}
