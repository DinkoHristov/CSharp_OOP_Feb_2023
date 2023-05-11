using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private readonly ICollection<IRacer> racers;

        public RacerRepository()
        {
            racers = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models
            => racers.ToList().AsReadOnly();

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Racer Repository");
            }

            racers.Add(model);
        }

        public IRacer FindBy(string property)
        {
            IRacer racer = racers.FirstOrDefault(r => r.Username == property);

            if (racer != null)
            {
                return racer;
            }

            return null;
        }

        public bool Remove(IRacer model)
        {
            if (racers.Any(r => r == model))
            {
                racers.Remove(model);

                return true;
            }

            return false;
        }
    }
}
