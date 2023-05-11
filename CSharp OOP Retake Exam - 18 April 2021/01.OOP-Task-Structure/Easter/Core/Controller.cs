using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private readonly BunnyRepository bunnies;
        private readonly EggRepository eggs;
        private Workshop workshop;

        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
            workshop = new Workshop();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            if (bunnyType != nameof(HappyBunny) &&
                bunnyType != nameof(SleepyBunny))
            {
                throw new InvalidOperationException("Invalid bunny type.");
            }

            IBunny bunny = null;

            if (bunnyType == nameof(HappyBunny))
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == nameof(SleepyBunny))
            {
                bunny = new SleepyBunny(bunnyName);
            }

            bunnies.Add(bunny);

            return $"Successfully added {bunnyType} named {bunnyName}.";
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IDye dye = new Dye(power);

            IBunny bunny = bunnies.Models.FirstOrDefault(b => b.Name == bunnyName);

            if (bunny == null)
            {
                throw new InvalidOperationException("The bunny you want to add a dye to doesn't exist!");
            }

            bunny.AddDye(dye);

            return $"Successfully added dye with power {power} to bunny {bunnyName}!";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);

            eggs.Add(egg);

            return $"Successfully added egg: {eggName}!";
        }

        public string ColorEgg(string eggName)
        {
            IEgg egg = eggs.Models.FirstOrDefault(e => e.Name == eggName);

            List<IBunny> readyBunnies = bunnies.Models.Where(b => b.Energy >= 50)
                .OrderByDescending(b => b.Energy)
                .ToList();

            if (readyBunnies.Count <= 0)
            {
                throw new InvalidOperationException("There is no bunny ready to start coloring!");
            }

            foreach (IBunny bunny in readyBunnies)
            {
                while (bunny.Dyes.Any(d => !d.IsFinished()))
                {
                    workshop.Color(egg, bunny);

                    if (egg.EnergyRequired <= 0)
                    {
                        break;
                    }
                }

                if (egg.EnergyRequired <= 0)
                {
                    break;
                }
            }

            if (egg.EnergyRequired > 0)
            {
                return $"Egg {eggName} is not done.";
            }

            return $"Egg {eggName} is done.";
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            int coloredEggs = 0;

            foreach (IEgg egg in eggs.Models)
            {
                if (egg.IsDone())
                {
                    coloredEggs++;
                }
            }

            result.AppendLine($"{coloredEggs} eggs are done!");
            result.AppendLine("Bunnies info:");

            foreach (IBunny bunny in bunnies.Models)
            {
                result.AppendLine($"Name: {bunny.Name}");
                result.AppendLine($"Energy: {bunny.Energy}");

                int notFinishedDyes = 0;

                foreach (IDye dye in bunny.Dyes)
                {
                    if (!dye.IsFinished())
                    {
                        notFinishedDyes++;
                    }
                }

                result.AppendLine($"Dyes: {notFinishedDyes} not finished");
            }

            return result.ToString().TrimEnd();
        }
    }
}
