using Gym.Models.Equipment.Contracts;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Gym.Models.Equipment
{
    public  class Equipment : IEquipment
    {
        public Equipment(double weight, decimal price)
        {
            Weight = weight;
            Price = price;
        }

        public double Weight { get; private set; }

        public decimal Price { get; private set; }
    }
}
