using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Paladin : BaseHero
    {
        private const int paladinPower = 100;

        public Paladin(string name) : base(name)
        {
            this.Power = paladinPower;
        }

        public override int Power { get; set; }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} healed for {Power}";
        }
    }
}
