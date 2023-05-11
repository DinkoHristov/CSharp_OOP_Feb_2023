using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private readonly ICollection<IEquipment> models;

        public EquipmentRepository()
        {
            models = new List<IEquipment>();
        }

        public IReadOnlyCollection<IEquipment> Models
            => models.ToList().AsReadOnly();

        public void Add(IEquipment model)
        {
            models.Add(model);
        }

        public IEquipment FindByType(string type)
        {
            IEquipment equipment = models.FirstOrDefault(e => e.GetType().Name == type);

            if (equipment != null)
            {
                return equipment;
            }

            return null;
        }

        public bool Remove(IEquipment model)
        {
            if (models.Any(m => m == model))
            {
                models.Remove(model);

                return true;
            }

            return false;
        }
    }
}
