using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double initialBaseHealth = 100;
        private const double initialBaseArmor = 50;
        private const double initialAbilityPoints = 40;
        private static Bag startingBag = new Satchel();

        public Warrior(string name) 
            : base(name, initialBaseHealth, initialBaseArmor, initialAbilityPoints, startingBag)
        {

        }

        public void Attack(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                if (this == character)
                {
                    throw new InvalidOperationException("Cannot attack self!");
                }

                character.TakeDamage(this.AbilityPoints);
            }
        }
    }
}
