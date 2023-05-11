using _03.Raiding.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            List<BaseHero> raidHeroes = new List<BaseHero>();

            int count = int.Parse(Console.ReadLine());

            int currCount = 0;

            while (currCount != count)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                BaseHero currHero = null;

                if (heroType == "Druid")
                {
                    currHero = new Druid(heroName);

                    raidHeroes.Add(currHero);
                    currCount++;
                }
                else if (heroType == "Paladin")
                {
                    currHero = new Paladin(heroName);

                    raidHeroes.Add(currHero);
                    currCount++;
                }
                else if (heroType == "Rogue")
                {
                    currHero = new Rogue(heroName);

                    raidHeroes.Add(currHero);
                    currCount++;
                }
                else if (heroType == "Warrior")
                {
                    currHero = new Warrior(heroName);

                    raidHeroes.Add(currHero);
                    currCount++;
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }

            }

            int bossPower = int.Parse(Console.ReadLine());

            int totalHeroesPower = 0;
            foreach (var hero in raidHeroes)
            {
                Console.WriteLine(hero.CastAbility());

                totalHeroesPower += hero.Power;
            }

            if (totalHeroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
