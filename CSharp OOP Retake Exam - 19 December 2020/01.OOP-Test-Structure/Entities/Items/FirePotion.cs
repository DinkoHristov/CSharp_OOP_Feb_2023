using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        private const int initialWeight = 5;

        public FirePotion()
            : base(initialWeight)
        {

        }

        public void AffectCharacter(Character character)
        {
            //TODO
            if (character.IsAlive)
            {
                character.TakeDamage(20);
            }
        }
    }
}
