using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class DomesticAssistant : Robot
    {
        private const int initialBatteryCapacity = 20000;
        private const int initialConvertionCapacity = 2000;

        public DomesticAssistant(string model) 
            : base(model, initialBatteryCapacity, initialConvertionCapacity)
        {

        }
    }
}
