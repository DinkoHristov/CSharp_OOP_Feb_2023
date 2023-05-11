using RobotService.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        private string model;
        private int batteryCapacity;
        private readonly ICollection<int> interfaceStandards;

        protected Robot(string model, int batteryCapacity, int convertionCapacityIndex)
        {
            Model = model;
            BatteryCapacity = batteryCapacity;
            BatteryLevel = BatteryCapacity;
            ConvertionCapacityIndex = convertionCapacityIndex;
            interfaceStandards = new List<int>();
        }

        public string Model { 
            get
            {
                return model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Model cannot be null or empty.");
                }

                model = value;
            }
        }

        public int BatteryCapacity {
            get
            {
                return batteryCapacity;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Battery capacity cannot drop below zero.");
                }

                batteryCapacity = value;
            }
        }

        public int BatteryLevel { get; private set; }

        public int ConvertionCapacityIndex { get; private set; }

        public IReadOnlyCollection<int> InterfaceStandards
            => interfaceStandards.ToList().AsReadOnly();

        public void Eating(int minutes)
        {
            int producedEnergy = ConvertionCapacityIndex * minutes;

            if (BatteryLevel == BatteryCapacity)
            {
                return;
            }

            BatteryLevel += producedEnergy;
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if (BatteryLevel >= consumedEnergy)
            {
                BatteryLevel -= consumedEnergy;

                return true;
            }

            return false;
        }

        public void InstallSupplement(ISupplement supplement)
        {
            interfaceStandards.Add(supplement.InterfaceStandard);

            BatteryCapacity -= supplement.BatteryUsage;

            BatteryLevel -= supplement.BatteryUsage;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{this.GetType().Name} {Model}:");
            result.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            result.AppendLine($"--Current battery level: {BatteryLevel}");

            if (interfaceStandards.Count > 0)
            {
                result.AppendLine($"--Supplements installed: {string.Join(" ", interfaceStandards)}");
            }
            else
            {
                result.AppendLine($"--Supplements installed: none");
            }

            return result.ToString().TrimEnd();
        }
    }
}
