using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private readonly ICollection<IEquipment> equipments;
        private readonly ICollection<IAthlete> athletes;

        protected Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            equipments = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }

        public string Name {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Gym name cannot be null or empty.");
                }

                name = value;
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight { 
            get
            {
                double totalWeight = 0;
                foreach (var currEquipment in equipments)
                {
                    totalWeight += currEquipment.Weight;
                }

                return totalWeight;
            }
        }

        public ICollection<IEquipment> Equipment
            => equipments.ToList().AsReadOnly();

        public ICollection<IAthlete> Athletes 
            => athletes.ToList().AsReadOnly();

        public void AddAthlete(IAthlete athlete)
        {
            if (Capacity <= athletes.Count)
            {
                throw new InvalidOperationException("Not enough space in the gym.");
            }

            athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            equipments.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{Name} is a {this.GetType().Name}:");

            if (athletes.Count > 0)
            {
                List<string> athNames = new List<string>();

                foreach (var athlete in athletes)
                {
                    athNames.Add(athlete.FullName);
                }

                result.AppendLine($"Athletes: {string.Join(", ", athNames)}");
            }
            else
            {
                result.AppendLine($"Athletes: No athletes");
            }

            result.AppendLine($"Equipment total count: {equipments.Count}");
            result.AppendLine($"Equipment total weight: {EquipmentWeight:F2} grams");

            return result.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            if (athletes.Any(a => a == athlete))
            {
                athletes.Remove(athlete);

                return true;
            }

            return false;
        }
    }
}
