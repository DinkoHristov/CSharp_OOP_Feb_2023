using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Warrior : BaseHero
    {
        private const int warriorPower = 100;

        public Warrior(string name) : base(name)
        {
            this.Power = warriorPower;
        }

        public override int Power { get; set; }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
