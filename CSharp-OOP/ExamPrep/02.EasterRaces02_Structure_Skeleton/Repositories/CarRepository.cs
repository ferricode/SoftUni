using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easterraces.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> races;

        public CarRepository()
        {
            races = new List<ICar>();
        }

        public void Add(ICar model)
        {
            races.Add(model);
        }

        public IReadOnlyCollection<ICar> GetAll() => races.ToList();


        public ICar GetByName(string name)
        {
            return races.FirstOrDefault(c => c.Model == name);
        }

        public bool Remove(ICar model) => races.Remove(model);
    }
}
