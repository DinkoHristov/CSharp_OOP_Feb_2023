using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly ICollection<IAstronaut> astronauts;

        public AstronautRepository()
        {
            astronauts = new List<IAstronaut>();
        }
        
        public IReadOnlyCollection<IAstronaut> Models
            => astronauts.ToList().AsReadOnly();

        public void Add(IAstronaut model)
        {
            astronauts.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
            IAstronaut astronaut = astronauts.FirstOrDefault(a => a.Name == name);

            if (astronaut != null)
            {
                return astronaut;
            }

            return null;
        }

        public bool Remove(IAstronaut model)
        {
            if (astronauts.Any(a => a == model))
            {
                astronauts.Remove(model);

                return true;
            }

            return false;
        }
    }
}
