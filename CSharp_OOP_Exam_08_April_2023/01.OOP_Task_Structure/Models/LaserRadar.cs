using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class LaserRadar : Supplement
    {
        private const int initialStandard = 20082;
        private const int initialBattery = 5000;

        public LaserRadar()
            : base(initialStandard, initialBattery)
        {

        }
    }
}
