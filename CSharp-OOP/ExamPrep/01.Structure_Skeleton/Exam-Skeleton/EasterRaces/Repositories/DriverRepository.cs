using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories
{
    public class DriverRepository : IRepository<IDriver>
    {

        private readonly List<IDriver> races;

        public DriverRepository()
        {
            races = new List<IDriver>();
        }

        public void Add(IDriver model)
        {
            races.Add(model);
        }

        public IReadOnlyCollection<IDriver> GetAll() => races.ToList();


        public IDriver GetByName(string name)
        {
            return races.FirstOrDefault(c => c.Name == name);
        }

        public bool Remove(IDriver model) => races.Remove(model);
    }
}

