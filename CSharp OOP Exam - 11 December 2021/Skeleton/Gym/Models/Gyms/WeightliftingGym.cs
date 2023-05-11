using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Gyms
{
    public class WeightliftingGym : Gym
    {
        private const int maxCapacity = 20;

        public WeightliftingGym(string name) 
            : base(name, maxCapacity)
        {

        }
    }
}
