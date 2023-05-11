using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly ICollection<ICar> cars;

        public CarRepository()
        {
            cars = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models
            => cars.ToList().AsReadOnly();

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Car Repository");
            }

            cars.Add(model);
        }

        public ICar FindBy(string property)
        {
            ICar car = cars.FirstOrDefault(c => c.VIN == property);

            if (car != null)
            {
                return car;
            }

            return null;
        }

        public bool Remove(ICar model)
        {
            if (cars.Any(c => c == model))
            {
                cars.Remove(model);

                return true;
            }

            return false;
        }
    }
}
