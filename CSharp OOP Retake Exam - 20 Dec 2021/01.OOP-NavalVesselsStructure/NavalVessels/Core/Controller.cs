using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private readonly VesselRepository vessels;
        private readonly ICollection<ICaptain> captains;

        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = captains.FirstOrDefault(c => c.FullName == selectedCaptainName);

            IVessel vessel = vessels.Models.FirstOrDefault(v => v.Name == selectedVesselName);

            if (captain == null)
            {
                return $"Captain {selectedCaptainName} could not be found.";
            }

            if (vessel == null)
            {
                return $"Vessel {selectedVesselName} could not be found.";
            }

            if (vessel.Captain != null)
            {
                return $"Vessel {selectedVesselName} is already occupied.";
            }

            vessel.Captain = captain;

            captain.Vessels.Add(vessel);

            return $"Captain {selectedCaptainName} command vessel {selectedVesselName}.";
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attacker = vessels.Models.FirstOrDefault(v => v.Name == attackingVesselName);

            IVessel deffender = vessels.Models.FirstOrDefault(v => v.Name == defendingVesselName);

            if (attacker == null)
            {
                return $"Vessel {attackingVesselName} could not be found.";
            }

            if (deffender == null)
            {
                return $"Vessel {defendingVesselName} could not be found.";
            }

            if (attacker.ArmorThickness == 0)
            {
                return $"Unarmored vessel {attackingVesselName} cannot attack or be attacked.";
            }

            if (deffender.ArmorThickness == 0)
            {
                return $"Unarmored vessel {defendingVesselName} cannot attack or be attacked.";
            }

            attacker.Attack(deffender);

            attacker.Captain.IncreaseCombatExperience();

            deffender.Captain.IncreaseCombatExperience();

            return $"Vessel {defendingVesselName} was attacked by vessel {attackingVesselName} - current armor thickness: {deffender.ArmorThickness}.";
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = captains.FirstOrDefault(c => c.FullName == captainFullName);

            if (captain != null)
            {
                return captain.Report();
            }

            return null;
        }

        public string HireCaptain(string fullName)
        {
            ICaptain captain = new Captain(fullName);

            if (captains.Any(c => c.FullName == fullName))
            {
                return $"Captain {fullName} is already hired.";
            }

            captains.Add(captain);

            return $"Captain {fullName} is hired.";
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel = null;

            if (vesselType == nameof(Submarine))
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == nameof(Battleship))
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else
            {
                return "Invalid vessel type.";
            }

            if (vessels.Models.Any(v => v.Name == name))
            {
                return $"{vesselType} vessel {name} is already manufactured.";
            }

            vessels.Add(vessel);

            return $"{vesselType} {name} is manufactured with the main weapon caliber of {mainWeaponCaliber} inches and a maximum speed of {speed} knots.";
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = vessels.Models.FirstOrDefault(v => v.Name == vesselName);

            if (vessel == null)
            {
                return $"Vessel {vesselName} could not be found.";
            }

            vessel.RepairVessel();

            return $"Vessel {vesselName} was repaired.";
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = vessels.Models.FirstOrDefault(v => v.Name == vesselName);

            if (vessel == null)
            {
                return $"Vessel {vesselName} could not be found.";
            }

            if (vessel.GetType().Name == nameof(Battleship))
            {
                ((Battleship)vessel).ToggleSonarMode();

                return $"Battleship {vesselName} toggled sonar mode.";
            }

            if (vessel.GetType().Name == nameof(Submarine))
            {
                ((Submarine)vessel).ToggleSubmergeMode();

                return $"Submarine {vesselName} toggled submerge mode.";
            }

            return null;
        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = vessels.Models.FirstOrDefault(v => v.Name == vesselName);

            if (vessel != null)
            {
                return vessel.ToString();
            }

            return null;
        }
    }
}
