using System;
using System.Collections.Generic;
using System.Text;

namespace AccessModifiers
{
   sealed class Child:Base //Sealed забранява на дадения клас да бъде наследяван. Може да се използва и за методи.
    {
        public Child()
        {
            this.protectedField = 5;

        }

        public double Weight { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

        public override void BaseMethod()
        {
            base.BaseMethod();
            Console.WriteLine("I am the child method");
        }
    }
}
