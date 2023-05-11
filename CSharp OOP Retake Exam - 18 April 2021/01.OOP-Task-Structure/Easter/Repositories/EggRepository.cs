using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private readonly ICollection<IEgg> eggs;

        public EggRepository()
        {
            eggs = new List<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models
            => eggs.ToList().AsReadOnly();

        public void Add(IEgg model)
        {
            eggs.Add(model);
        }

        public IEgg FindByName(string name)
        {
            IEgg egg = eggs.FirstOrDefault(e => e.Name == name);

            if (egg != null)
            {
                return egg;
            }

            return null;
        }

        public bool Remove(IEgg model)
        {
            if (eggs.Any(e => e == model))
            {
                eggs.Remove(model);

                return true;
            }

            return false;
        }
    }
}
