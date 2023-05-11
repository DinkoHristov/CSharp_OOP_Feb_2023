using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Rogue : BaseHero
    {
        private const int roguePower = 80;

        public Rogue(string name) : base(name)
        {
            this.Power = roguePower;
        }

        public override int Power { get; set; }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
