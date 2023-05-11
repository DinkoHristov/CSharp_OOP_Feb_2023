using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly ICollection<IPlanet> planets;

        public PlanetRepository()
        {
            planets = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models
            => planets.ToList().AsReadOnly();

        public void Add(IPlanet model)
        {
            planets.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            IPlanet planet = planets.FirstOrDefault(a => a.Name == name);

            if (planet != null)
            {
                return planet;
            }

            return null;
        }

        public bool Remove(IPlanet model)
        {
            if (planets.Any(a => a == model))
            {
                planets.Remove(model);

                return true;
            }

            return false;
        }
    }
}
