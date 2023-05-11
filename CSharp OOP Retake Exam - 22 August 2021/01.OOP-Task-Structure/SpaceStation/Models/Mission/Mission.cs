using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            string[] copyItems = new string[planet.Items.Count];

            for (int i = 0; i < copyItems.Length; i++)
            {
                copyItems[i] = planet.Items.ToArray()[i];
            }

            foreach (IAstronaut currAstronaut in astronauts)
            {
                for (int i = 0; i < copyItems.Length; i++)
                {
                    string currItem = copyItems[i];

                    if (currItem != null)
                    {
                        if (currAstronaut.Oxygen > 0)
                        {
                            currAstronaut.Bag.Items.Add(currItem);

                            copyItems[i] = null;

                            currAstronaut.Breath();
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
        }
    }
}
