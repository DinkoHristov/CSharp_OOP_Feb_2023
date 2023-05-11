using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private readonly CarRepository cars;
        private readonly RacerRepository racers;
        private readonly IMap map;

        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            if (type != nameof(SuperCar) &&
                type != nameof(TunedCar))
            {
                throw new ArgumentException("Invalid car type!");
            }

            ICar car = null;

            if (type == nameof(SuperCar))
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            else if (type == nameof(TunedCar))
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }

            cars.Add(car);

            return $"Successfully added car {make} {model} ({VIN}).";
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = cars.Models.FirstOrDefault(c => c.VIN == carVIN);

            if (car == null)
            {
                throw new ArgumentException("Car cannot be found!");
            }

            if (type != nameof(ProfessionalRacer) &&
                type != nameof(StreetRacer))
            {
                throw new ArgumentException("Invalid racer type!");
            }

            IRacer racer = null;

            if (type == nameof(ProfessionalRacer))
            {
                racer = new ProfessionalRacer(username, car);
            }
            else if (type == nameof(StreetRacer))
            {
                racer = new StreetRacer(username, car);
            }

            racers.Add(racer);

            return $"Successfully added racer {username}.";
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = racers.Models.FirstOrDefault(r => r.Username == racerOneUsername);

            IRacer racerTwo = racers.Models.FirstOrDefault(r => r.Username == racerTwoUsername);

            if (racerOne == null)
            {
                throw new ArgumentException($"Racer {racerOneUsername} cannot be found!");
            }

            if (racerTwo == null)
            {
                throw new ArgumentException($"Racer {racerTwoUsername} cannot be found!");
            }

            return map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            foreach (IRacer racer in racers.Models
                .OrderByDescending(r => r.DrivingExperience)
                .ThenBy(r => r.Username))
            {
                result.AppendLine($"{racer.GetType().Name}: {racer.Username}");
                result.AppendLine($"--Driving behavior: {racer.RacingBehavior}");
                result.AppendLine($"--Driving experience: {racer.DrivingExperience}");
                result.AppendLine($"--Car: {racer.Car.Make} {racer.Car.Model} ({racer.Car.VIN})");
            }

            return result.ToString().TrimEnd();
        }
    }
}
