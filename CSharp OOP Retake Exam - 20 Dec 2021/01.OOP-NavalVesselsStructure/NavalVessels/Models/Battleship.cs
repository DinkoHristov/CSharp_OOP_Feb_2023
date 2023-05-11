using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Battleship : Vessel
    {
        private const int BattleshipArmorThickness = 300;
        private bool sonarMode;

        public Battleship(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, BattleshipArmorThickness)
        {
            SonarMode = false;
        }

        public bool SonarMode { 
            get
            {
                return this.sonarMode;
            }
            private set
            {
                this.sonarMode = value;
            }
        }

        public void ToggleSonarMode()
        {
            if (SonarMode)
            {
                SonarMode = false;

                MainWeaponCaliber -= 40;

                Speed += 5;
            }
            else
            {
                SonarMode = true;

                MainWeaponCaliber += 40;

                Speed -= 5;
            }
        }

        public override void RepairVessel()
        {
            if (ArmorThickness < 300)
            {
                //It was attacked
                ArmorThickness = BattleshipArmorThickness;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString());

            if (SonarMode)
            {
                result.AppendLine($" *Sonar mode: ON");
            }
            else
            {
                result.AppendLine($" *Sonar mode: OFF");
            }

            return result.ToString().TrimEnd();
        }
    }
}
