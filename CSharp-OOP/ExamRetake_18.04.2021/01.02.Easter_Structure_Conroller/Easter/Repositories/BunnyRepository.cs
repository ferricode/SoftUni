using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly List<IBunny> models;

        public BunnyRepository()
        {
            models = new List<IBunny>();
        }
        public IReadOnlyCollection<IBunny> Models => models.ToList();

        public void Add(IBunny model) // IBunny Bunny
        {
            models.Add(model);
        }

        public IBunny FindByName(string name)
        {
            var foundBunny = models.FirstOrDefault(b => b.Name == name);
            if (foundBunny!=null)
            {
                return foundBunny;
            }
            return null;
        }

        public bool Remove(IBunny model)
        {
            
            if (models.Contains(model))
            {
                models.Remove(model);
                return true;
            }
            return false;
        }
    }
}
