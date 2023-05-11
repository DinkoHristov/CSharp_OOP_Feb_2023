using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double initialFuelAbvailable = 65;
        private const double initialFuelConsumption = 7.5;

        public TunedCar(string make, string model, string vIN, int horsePower) 
            : base(make, model, vIN, horsePower, initialFuelAbvailable, initialFuelConsumption)
        {

        }

        public override void Drive()
        {
            base.Drive();

            double reduction = HorsePower * (3 / 100.0);
            int closestReductionPoint = (int)Math.Round(HorsePower - reduction);

            HorsePower = closestReductionPoint;
        }
    }
}
