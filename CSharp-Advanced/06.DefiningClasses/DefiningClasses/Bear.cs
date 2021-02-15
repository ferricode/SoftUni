using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class Bear
    {
        public string Name { get; set; }

        public int DaysSinceEaten { get; set; }

        public int Age { get; set; }

        //Behaviour

        public void Eat()
        {
            Console.WriteLine($"The bear {Name} just eat and is happy   ");
        }
    }
}
