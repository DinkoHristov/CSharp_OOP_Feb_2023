using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private readonly EquipmentRepository equipment;
        private readonly ICollection<IGym> gyms;

        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            if (athleteType != nameof(Boxer) &&
                athleteType != nameof(Weightlifter))
            {
                throw new InvalidOperationException("Invalid athlete type.");
            }

            IAthlete athlete = null;

            if (athleteType == nameof(Boxer))
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteType == nameof(Weightlifter))
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }

            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);

            if ((gym.GetType().Name == nameof(BoxingGym) && athleteType == nameof(Weightlifter)) ||
                (gym.GetType().Name == nameof (WeightliftingGym) && athleteType == nameof(Boxer)))
            {
                return $"The gym is not appropriate.";
            }

            gym.AddAthlete(athlete);

            return $"Successfully added {athleteType} to {gymName}.";
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType != nameof(BoxingGloves) &&
                equipmentType != nameof(Kettlebell))
            {
                throw new InvalidOperationException("Invalid equipment type.");
            }

            IEquipment currEquipment = null;

            if (equipmentType == nameof(BoxingGloves))
            {
                currEquipment = new BoxingGloves();
            }
            else if (equipmentType == nameof(Kettlebell))
            {
                currEquipment = new Kettlebell();
            }

            equipment.Add(currEquipment);

            return $"Successfully added {equipmentType}.";
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType != nameof(BoxingGym) &&
                gymType != nameof(WeightliftingGym))
            {
                throw new InvalidOperationException("Invalid gym type.");
            }

            IGym gym = null;

            if (gymType == nameof(BoxingGym))
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == nameof(WeightliftingGym))
            {
                gym = new WeightliftingGym(gymName);
            }

            gyms.Add(gym);

            return $"Successfully added {gymType}.";
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);

            double value = gym.EquipmentWeight;

            return $"The total weight of the equipment in the gym {gymName} is {value:F2} grams.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment currEquipment = equipment.Models
                .FirstOrDefault(e => e.GetType().Name == equipmentType);

            if (currEquipment == null)
            {
                throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}.");
            }

            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);

            gym.AddEquipment(currEquipment);

            equipment.Remove(currEquipment);

            return $"Successfully added {equipmentType} to {gymName}.";
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            foreach (IGym gym in gyms)
            {
                result.AppendLine(gym.GymInfo());
            }

            return result.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);

            gym.Exercise();

            return $"Exercise athletes: {gym.Athletes.Count}.";
        }
    }
}
