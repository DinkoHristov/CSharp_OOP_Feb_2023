using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class SpecializedArm : Supplement
    {
        private const int initialStandard = 10045;
        private const int initialBattery = 10000;

        public SpecializedArm() 
            : base(initialStandard, initialBattery)
        {

        }
    }
}
