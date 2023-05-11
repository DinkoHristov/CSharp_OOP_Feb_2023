using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Repositories.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Formula1.Core.Contracts
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;

        public Controller()
        {
            this.pilotRepository = new PilotRepository();
            this.raceRepository = new RaceRepository();
            this.carRepository = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IFormulaOneCar car = this.carRepository.Models.FirstOrDefault(c => c.Model == carModel);
            IPilot pilot = this.pilotRepository.Models.FirstOrDefault(p => p.FullName == pilotName);

            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException($"Pilot {pilotName} does not exist or has a car.");
            }

            if (car == null)
            {
                throw new NullReferenceException($"Car {carModel} does not exist.");
            }

            pilot.AddCar(car);

            carRepository.Remove(car);

            return $"Pilot {pilotName} will drive a {car.GetType().Name} {carModel} car.";
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = this.raceRepository.Models.FirstOrDefault(r => r.RaceName == raceName);
            IPilot pilot = this.pilotRepository.Models.FirstOrDefault(p => p.FullName == pilotFullName);

            if (race == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }

            if (pilot == null || !pilot.CanRace || race.Pilots.Any(p => p.FullName == pilotFullName))
            {
                throw new InvalidOperationException($"Can not add pilot {pilotFullName } to the race.");
            }

            race.AddPilot(pilot);

            return $"Pilot {pilotFullName} is added to the {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car;

            if (type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException($"Formula one car type {type} is not valid.");
            }

            if (this.carRepository.Models.Any(x => x.Model == model))
            {
                throw new InvalidOperationException($"Formula one car {model} is already created.");
            }

            this.carRepository.Add(car);

            return $"Car {type}, model {model} is created.";
        }

        public string CreatePilot(string fullName)
        {
            IPilot pilot = new Pilot(fullName);

            if (this.pilotRepository.Models.Any(p => p.FullName == fullName))
            {
                throw new InvalidOperationException($"Pilot {fullName} is already created.");
            }

            this.pilotRepository.Add(pilot);

            return $"Pilot {fullName} is created.";
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace race = new Race(raceName, numberOfLaps);

            if (this.raceRepository.Models.Any(r => r.RaceName == raceName))
            {
                throw new InvalidOperationException($"Race {raceName} is already created.");
            }

            this.raceRepository.Add(race);

            return $"Race {raceName} is created.";
        }

        public string PilotReport()
        {
            StringBuilder result = new StringBuilder();

            foreach (var pilot in pilotRepository.Models
                .OrderByDescending(wins => wins.NumberOfWins))
            {
                result.AppendLine(pilot.ToString());
            }

            return result.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder result = new StringBuilder();

            foreach (var race in raceRepository.Models
                .Where(tp => tp.TookPlace))
            {
                result.AppendLine(race.RaceInfo());
            }

            return result.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.Models.FirstOrDefault(r => r.RaceName == raceName);

            if (race == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }

            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than three participants.");
            }

            if (race.TookPlace)
            {
                throw new InvalidOperationException($"Can not execute race {raceName}.");
            }

            SortedList<double, IPilot> raceScore = new SortedList<double, IPilot>();

            foreach (var currPilot in race.Pilots)
            {
                double points = currPilot.Car.RaceScoreCalculator(race.NumberOfLaps);

                raceScore.Add(points, currPilot);
            }

            StringBuilder result = new StringBuilder();

            int count = 1;
            foreach (var pilot in raceScore
                .OrderByDescending(p => p.Key)
                .Take(3))
            {
                if (count == 1)
                {
                    result.AppendLine($"Pilot {pilot.Value.FullName} wins the {raceName} race.");

                    pilot.Value.WinRace();

                    race.TookPlace = true;
                }
                else if (count == 2)
                {
                    result.AppendLine($"Pilot {pilot.Value.FullName} is second in the {raceName} race.");
                }
                else
                {
                    result.AppendLine($"Pilot {pilot.Value.FullName} is third in the {raceName} race.");
                }

                count++;
            }

            return result.ToString().TrimEnd();
        }
    }
}