using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Car : Vehicle
    {
        private const double fuelIncrese = 0.9;

        public Car(double fuelQuantity, double litersPerKm) 
            : base(fuelQuantity, litersPerKm)
        {

        }

        public override string Drive(double kilometers)
        {
            double neededFuel = (this.LitersPerKm + fuelIncrese) * kilometers;

            if (this.FuelQuantity >= neededFuel)
            {
                this.FuelQuantity -= neededFuel;

                return $"{this.GetType().Name} travelled {kilometers} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public override void Refuel(double litersToAdd)
        {
           this. FuelQuantity += litersToAdd;
        }
    }
}
