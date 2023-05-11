using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IFormulaOneCarRepository
    {
        //TODO change all abstract classes in collections with interfaces
        private List<IFormulaOneCar> models;

        public FormulaOneCarRepository()
        {
            this.models = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models
            => this.models;

        public void Add(IFormulaOneCar model)
        {
            this.models.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            IFormulaOneCar f1Car = this.models.FirstOrDefault(car => car.Model == name);

            if (f1Car != null)
            {
                return f1Car;
            }

            return null;
        }

        public bool Remove(IFormulaOneCar model)
        {
            if (this.models.Any(car => car == model))
            {
                this.models.Remove(model);

                return true;
            }

            return false;
        }
    }
}
