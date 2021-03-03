using System;
using System.Collections.Generic;
using System.Text;

namespace EncapsulationDemo
{
    public class Kitchen
    {
        private int meat;
        private int garlic;

        public Kitchen(int meat, int garlic)
        {
            this.meat = 100;
            this.garlic = 100;
        }
        public bool MeatballsLef { get { return meat > 10 && garlic >= 3} }

        public void OrderMeatball()
        {
            if (CookMeatball())
            {
                Console.WriteLine("Meatball cooked");
            }
            else
            {
                Console.WriteLine("Not enough materials for a meatball");
            }
        }
        private bool CookMeatball()
        {
            Console.WriteLine("Meatball being cooked");

            if (meat < 10 || garlic < 3)
            {
                return false;
            }
            meat -= 10;
            garlic -= 3;
            return true;
        }

    }
}
