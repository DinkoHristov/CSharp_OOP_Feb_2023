using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Druid : BaseHero
    {
        private const int druidPower = 80;

        public Druid(string name) 
            : base(name)
        {
            this.Power = druidPower;
        }

        public override int Power { get; set; }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} healed for {Power}";
        }
    }
}
