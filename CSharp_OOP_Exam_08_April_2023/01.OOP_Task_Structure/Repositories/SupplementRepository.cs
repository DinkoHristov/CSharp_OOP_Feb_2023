using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private readonly ICollection<ISupplement> items;

        public SupplementRepository()
        {
            items = new List<ISupplement>();
        }

        public void AddNew(ISupplement model)
        {
            items.Add(model);
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
            ISupplement supplement = items.FirstOrDefault(s => s.InterfaceStandard == interfaceStandard);

            if (supplement != null)
            {
                return supplement;
            }

            return null;
        }

        public IReadOnlyCollection<ISupplement> Models()
            => items.ToList().AsReadOnly();

        public bool RemoveByName(string typeName)
        {
            ISupplement supplement = items.FirstOrDefault(s => s.GetType().Name == typeName);

            if (supplement != null)
            {
                items.Remove(supplement);

                return true;
            }

            return false;
        }
    }
}
