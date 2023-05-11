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
        private readonly ICollection<IBunny> bunnies;

        public BunnyRepository()
        {
            bunnies = new List<IBunny>();
        }

        public IReadOnlyCollection<IBunny> Models
            => bunnies.ToList().AsReadOnly();

        public void Add(IBunny model)
        {
            bunnies.Add(model);
        }

        public IBunny FindByName(string name)
        {
            IBunny bunny = bunnies.FirstOrDefault(b => b.Name == name);

            if (bunny != null)
            {
                return bunny;
            }

            return null;
        }

        public bool Remove(IBunny model)
        {
            if (bunnies.Any(b => b == model))
            {
                bunnies.Remove(model);

                return true;
            }

            return false;
        }
    }
}
