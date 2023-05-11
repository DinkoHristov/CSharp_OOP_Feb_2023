using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Core.Contracts
{
    public class Controller : IController
    {
        private int exploredPlanets = 0;

        private readonly AstronautRepository astronauts;
        private readonly PlanetRepository planets;

        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            if (type != nameof(Biologist) &&
                type != nameof(Geodesist) &&
                type != nameof(Meteorologist))
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }

            IAstronaut astronaut = null;

            if (type == nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == nameof(Geodesist))
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == nameof(Meteorologist))
            {
                astronaut = new Meteorologist(astronautName);
            }

            astronauts.Add(astronaut);

            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (string item in items)
            {
                planet.Items.Add(item);
            }

            planets.Add(planet);

            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);

            List<IAstronaut> astronautsOnMission = new List<IAstronaut>();

            bool isOneAstronautFound = false;

            foreach (IAstronaut astronaut in astronauts.Models)
            {
                if (astronaut.Oxygen > 60)
                {
                    astronautsOnMission.Add(astronaut);

                    isOneAstronautFound = true;
                }
            }

            if (!isOneAstronautFound)
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }

            Mission mission = new Mission();

            mission.Explore(planet, astronautsOnMission);

            int corps = 0;

            foreach (IAstronaut current in astronautsOnMission)
            {
                if (current.Oxygen <= 0)
                {
                    corps++;
                }
            }

            exploredPlanets++;

            return $"Planet: {planetName} was explored! Exploration finished with {corps} dead astronauts!";
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{exploredPlanets} planets were explored!");
            result.AppendLine("Astronauts info:");

            foreach (IAstronaut astronaut in astronauts.Models)
            {
                result.AppendLine($"Name: {astronaut.Name}");
                result.AppendLine($"Oxygen: {astronaut.Oxygen}");

                if (astronaut.Bag.Items.Count > 0)
                {
                    result.AppendLine($"Bag items: {string.Join(", ", astronaut.Bag.Items)}");
                }
                else
                {
                    result.AppendLine("Bag items: none");
                }
            }

            return result.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronauts.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }

            astronauts.Remove(astronaut);

            return $"Astronaut {astronautName} was retired!";
        }
    }
}
