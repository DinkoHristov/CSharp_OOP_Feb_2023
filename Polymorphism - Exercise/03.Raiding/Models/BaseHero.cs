using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public abstract class BaseHero
    {
        protected BaseHero(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public abstract int Power { get; set; }

        public abstract string CastAbility();
    }
}
