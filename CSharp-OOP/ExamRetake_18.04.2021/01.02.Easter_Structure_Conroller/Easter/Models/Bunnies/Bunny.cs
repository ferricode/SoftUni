
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;
        private readonly List<IDye> dyes;

        protected Bunny(string name, int energy)
        {
            Name = name;
            Energy = energy;
            dyes = new List<IDye>();
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }
                name = value;
            }
        }
        public int Energy
        {
            get => energy;

            protected set
            {
                energy = Math.Max(value, 0);
            }
        }
        public ICollection<IDye> Dyes  => dyes.ToList();

        public void AddDye(IDye dye)
        {
            dyes.Add(dye);
        }
        public abstract void Work();
        //{
        //    Energy -= 10;
        //    if (Energy < 0)
        //    {
        //        Energy = 0;
        //    }
        //}
    }
}
