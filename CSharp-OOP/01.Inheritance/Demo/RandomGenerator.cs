using System;
using System.Collections.Generic;
using System.Text;

namespace DemoInheritance
{
   public  class RandomGenerator
    {
        private static Random random = new Random();

        public int Next(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
