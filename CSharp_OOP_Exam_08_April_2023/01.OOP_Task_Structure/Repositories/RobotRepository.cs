using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private readonly ICollection<IRobot> items;

        public RobotRepository()
        {
            items = new List<IRobot>();
        }

        public void AddNew(IRobot model)
        {
            items.Add(model);
        }

        public IRobot FindByStandard(int interfaceStandard)
        {
            IRobot robot = items.FirstOrDefault(r => r.InterfaceStandards.Any(r => r == interfaceStandard));

            if (robot != null)
            {
                return robot;
            }

            return null;
        }

        public IReadOnlyCollection<IRobot> Models()
            => items.ToList().AsReadOnly();

        public bool RemoveByName(string typeName)
        {
            IRobot robot = items.FirstOrDefault(r => r.Model == typeName);

            if (robot != null)
            {
                items.Remove(robot);

                return true;
            }

            return false;
        }
    }
}
