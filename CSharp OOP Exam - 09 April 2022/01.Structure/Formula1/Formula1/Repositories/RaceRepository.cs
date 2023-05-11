using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class RaceRepository : IRaceRepository
    {
        private readonly List<IRace> models;

        public RaceRepository()
        {
            this.models = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models
            => this.models;

        public void Add(IRace model)
        {
            this.models.Add(model);
        }

        public IRace FindByName(string name)
        {
            IRace race = this.models.FirstOrDefault(r => r.RaceName == name);

            if (race != null)
            {
                return race;
            }

            return null;
        }

        public bool Remove(IRace model)
        {
            if (this.models.Any(r => r == model))
            {
                this.models.Remove(model);

                return true;
            }

            return false;
        }
    }
}
