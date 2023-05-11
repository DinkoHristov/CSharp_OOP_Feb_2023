using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private SupplementRepository supplements;
        private RobotRepository robots;

        public Controller()
        {
            supplements = new SupplementRepository();
            robots = new RobotRepository();
        }

        public string CreateRobot(string model, string typeName)
        {
            if (typeName != nameof(DomesticAssistant) &&
                typeName != nameof(IndustrialAssistant))
            {
                return $"Robot type {typeName} cannot be created.";
            }

            IRobot robot = null;

            if (typeName == nameof(DomesticAssistant))
            {
                robot = new DomesticAssistant(model);
            }
            else if (typeName == nameof(IndustrialAssistant))
            {
                robot = new IndustrialAssistant(model);
            }

            robots.AddNew(robot);

            return $"{typeName} {model} is created and added to the RobotRepository.";
        }

        public string CreateSupplement(string typeName)
        {
            if (typeName != nameof(SpecializedArm) &&
                typeName != nameof(LaserRadar))
            {
                return $"{typeName} is not compatible with our robots.";
            }

            ISupplement supplement = null;

            if (typeName == nameof(SpecializedArm))
            {
                supplement = new SpecializedArm();
            }
            else if (typeName == nameof(LaserRadar))
            {
                supplement = new LaserRadar();
            }

            supplements.AddNew(supplement);

            return $"{typeName} is created and added to the SupplementRepository.";
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            List<IRobot> containgStandardRobots = robots
                .Models()
                .Where(r => r.InterfaceStandards.Any(i => i == intefaceStandard))
                .ToList();

            if (containgStandardRobots.Count <= 0)
            {
                return $"Unable to perform service, {intefaceStandard} not supported!";
            }

            containgStandardRobots = containgStandardRobots
                .OrderByDescending(r => r.BatteryLevel)
                .ToList();

            int batterySum = 0;

            foreach (IRobot robot in containgStandardRobots)
            {
                batterySum += robot.BatteryLevel;
            }

            if (batterySum < totalPowerNeeded)
            {
                return $"{serviceName} cannot be executed! {totalPowerNeeded - batterySum} more power needed.";
            }

            int robotsTakePart = 0;

            bool isFinished = false;

            while (totalPowerNeeded > 0)
            {
                foreach (IRobot robot in containgStandardRobots)
                {
                    if (robot.BatteryLevel >= totalPowerNeeded)
                    {
                        robot.ExecuteService(totalPowerNeeded);

                        robotsTakePart++;

                        isFinished = true;
                    }
                    else
                    {
                        totalPowerNeeded -= robot.BatteryLevel;

                        robot.ExecuteService(robot.BatteryLevel);

                        robotsTakePart++;
                    }

                    if (isFinished)
                    {
                        break;
                    }
                }

                if (isFinished)
                {
                    break;
                }
            }

            return $"{serviceName} is performed successfully with {robotsTakePart} robots.";
        }

        public string Report()
        {
            List<IRobot> searchedRobots = robots
                .Models()
                .OrderByDescending(r => r.BatteryLevel)
                .ThenBy(r => r.BatteryCapacity)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach(IRobot robot in searchedRobots)
            {
                result.AppendLine($"{robot.ToString()}");
            }

            return result.ToString().TrimEnd();
        }

        public string RobotRecovery(string model, int minutes)
        {
            List<IRobot> currRobots = robots
                .Models()
                .Where(r => r.Model == model)
                .ToList();

            currRobots = currRobots
                .Where(r => r.BatteryLevel < (r.BatteryCapacity * 0.5))
                .ToList();

            foreach (IRobot robot in currRobots)
            {
                robot.Eating(minutes);
            }

            return $"Robots fed: {currRobots.Count}";
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = supplements
                .Models()
                .FirstOrDefault(s => s.GetType().Name == supplementTypeName);

            List<IRobot> robotModels = robots
                .Models()
                .Where(r => r.Model == model)
                .ToList();

            List<IRobot> notContainingRobots = new List<IRobot>();

            foreach (IRobot currRobot in robotModels)
            {
                bool isSupplementFound = false;

                foreach (var value in currRobot.InterfaceStandards)
                {
                    if (value == supplement.InterfaceStandard)
                    {
                        isSupplementFound = true;

                        break;
                    }
                }

                if (!isSupplementFound)
                {
                    notContainingRobots.Add(currRobot);
                }
            }

            if (notContainingRobots.Count <= 0)
            {
                return $"All {model} are already upgraded!";
            }

            IRobot robot = notContainingRobots.FirstOrDefault();

            robot.InstallSupplement(supplement);

            supplements.RemoveByName(supplementTypeName);

            return $"{model} is upgraded with {supplementTypeName}.";
        }
    }
}
