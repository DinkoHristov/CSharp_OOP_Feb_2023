using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        private const double fuelIncrese = 1.6;

        public Truck(double fuelQuantity, double litersPerKm) 
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
            double literRefueled = litersToAdd * 95 / 100;

            this.FuelQuantity += literRefueled;
        }
    }
}
