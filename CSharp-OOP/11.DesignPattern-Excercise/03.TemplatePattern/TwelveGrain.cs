using System;
using System.Collections.Generic;
using System.Text;

namespace _03.TemplatePattern
{
    public class TwelveGrain : Bread
    {

        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for 12=Grain bread!");
        }
        public override void Bake()
        {
            Console.WriteLine("Baking yhe 12-Grain bread! (25 minutes)");
        }

        
    }
}
