using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        private const double fuelIncrese = 0.9;

        public Car(double fuelQuantity, double litersPerKm, double tankCapacity) 
            : base(fuelQuantity, litersPerKm, tankCapacity)
        {

        }

        public override string Drive(double kilometers)
        {
            double neededFuel = (LitersPerKm + fuelIncrese) * kilometers;

            if (FuelQuantity >= neededFuel)
            {
                FuelQuantity -= neededFuel;

                return $"{GetType().Name} travelled {kilometers} km";
            }

            return $"{GetType().Name} needs refueling";
        }

        public override void Refuel(double litersToAdd)
        {
            if (litersToAdd <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            double addedFuel = this.FuelQuantity + litersToAdd;

            if (addedFuel > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {litersToAdd} fuel in the tank");
            }

            this.FuelQuantity += litersToAdd;
        }
    }
}
