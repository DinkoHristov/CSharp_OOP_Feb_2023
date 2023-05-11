using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        private const double initialFuelAbvailable = 80;
        private const double initialFuelConsumption = 10;

        public SuperCar(string make, string model, string vIN, int horsePower) 
            : base(make, model, vIN, horsePower, initialFuelAbvailable, initialFuelConsumption)
        {

        }
    }
}
