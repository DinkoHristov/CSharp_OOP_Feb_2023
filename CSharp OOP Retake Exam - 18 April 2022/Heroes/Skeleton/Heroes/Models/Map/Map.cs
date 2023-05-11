using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            bool isBarbarianWon = false;
            bool isKnightWon = false;

            int deadBarbarians = 0;
            int deadKnights = 0;

            List<IHero> knights = players.Where(p => p.GetType().Name == "Knight").ToList();
            List<IHero> barbarians = players.Where(p => p.GetType().Name == "Barbarian").ToList();

            int turn = 1;

            while (!isBarbarianWon && !isKnightWon)
            {
                if (turn == 1)
                {
                    for (int i = 0; i < knights.Count; i++)
                    {
                        IHero currKnight = knights[i];

                        for (int j = 0; j < barbarians.Count; j++)
                        {
                            barbarians[j].TakeDamage(currKnight.Weapon.DoDamage());

                            if (barbarians[j].Health <= 0)
                            {
                                deadBarbarians++;
                            }
                        }

                        barbarians = barbarians.Where(b => b.Health > 0).ToList();
                    }

                    turn = 2;
                }
                else
                {
                    for (int i = 0; i < barbarians.Count; i++)
                    {
                        IHero currBarbarian = barbarians[i];

                        for (int j = 0; j < knights.Count; j++)
                        {
                            knights[j].TakeDamage(currBarbarian.Weapon.DoDamage());

                            if (knights[j].Health <= 0)
                            {
                                deadKnights++;
                            }
                        }

                        knights = knights.Where(b => b.Health > 0).ToList();
                    }

                    turn = 1;
                }

                if (barbarians.Count <= 0)
                {
                    isKnightWon = true;
                    break;
                }

                if (knights.Count <= 0)
                {
                    isBarbarianWon = true;
                    break;
                }
            }

            if (isBarbarianWon)
            {
                return $"The barbarians took {deadBarbarians} casualties but won the battle.";
            }
            else
            {
                return $"The knights took {deadKnights} casualties but won the battle.";
            }
        }
    }
}
