using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const double initialBaseHealth = 50;
        private const double initialBaseArmor = 25;
        private const double initialAbilityPoints = 40;
        private static Bag startingBag = new Backpack();

        public Priest(string name)
            : base(name, initialBaseHealth, initialBaseArmor, initialAbilityPoints, startingBag)
        {

        }

        public void Heal(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                character.Health += this.AbilityPoints;
            }
        }
    }
}
