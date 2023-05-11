using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const double weightGloves = 227;
        private const decimal priceGloves = 120;

        public BoxingGloves() 
            : base(weightGloves, priceGloves)
        {

        }
    }
}
