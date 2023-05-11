using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Submarine : Vessel
    {
        private const int SubmarineArmorThickness = 200;
        private bool submergeMode;

        public Submarine(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, SubmarineArmorThickness)
        {
            SubmergeMode = false;
        }

        public bool SubmergeMode {
            get
            {
                return this.submergeMode;
            }
            private set
            {
                this.submergeMode = value;
            }
        }

        public void ToggleSubmergeMode()
        {
            if (SubmergeMode)
            {
                SubmergeMode = false;

                MainWeaponCaliber -= 40;

                Speed += 4;
            }
            else
            {
                SubmergeMode = true;

                MainWeaponCaliber += 40;

                Speed -= 4;
            }
        }

        public override void RepairVessel()
        {
            if (ArmorThickness < 200)
            {
                //It was attacked
                ArmorThickness = SubmarineArmorThickness;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString());

            if (SubmergeMode)
            {
                result.AppendLine($" *Submerge mode: ON");
            }
            else
            {
                result.AppendLine($" *Submerge mode: OFF");
            }

            return result.ToString().TrimEnd();
        }
    }
}
