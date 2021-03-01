using System;
using System.Collections.Generic;
using System.Text;

namespace AccessModifiers
{
    class Base
    {
        private int privateField; // Вижда се само вътре в настоящия клас.
        protected int protectedField; // Вижда се само от настоящия клас и от "децата му"(класовете, които го наследяват)
        internal int internalField; // Вижда се само в настоящият проект.
        public int publicField;//Може да се вижда от целия проект също и от други проекти

        public Base()
        { }

        public virtual void BaseMethod()
        {
            Console.WriteLine("I am the base method");
        }
    }
}
