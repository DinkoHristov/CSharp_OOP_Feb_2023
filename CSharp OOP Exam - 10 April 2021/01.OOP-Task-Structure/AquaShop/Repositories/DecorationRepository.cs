using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly ICollection<IDecoration> decorations;

        public DecorationRepository()
        {
            decorations = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models
            => decorations.ToList().AsReadOnly();

        public void Add(IDecoration model)
        {
            decorations.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            IDecoration decoration = decorations.FirstOrDefault(d => d.GetType().Name == type);

            if (decoration != null)
            {
                return decoration;
            }

            return null;
        }

        public bool Remove(IDecoration model)
        {
            if (decorations.Any(d => d == model))
            {
                decorations.Remove(model);

                return true;
            }

            return false;
        }
    }
}
