using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double fuelWithPeople = 1.4;

        public Bus(double fuelQuantity, double litersPerKm, double tankCapacity)
            : base(fuelQuantity, litersPerKm, tankCapacity)
        {

        }

        public string DriveWithoutPeople(double kilometers)
        {
            double neededFuel = LitersPerKm * kilometers;

            if (FuelQuantity >= neededFuel)
            {
                FuelQuantity -= neededFuel;

                return $"{GetType().Name} travelled {kilometers} km";
            }

            return $"{GetType().Name} needs refueling";
        }

        public override string Drive(double kilometers)
        {
            double neededFuel = (LitersPerKm + fuelWithPeople) * kilometers;

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


            if (addedFuel > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {litersToAdd} fuel in the tank");
            }

            FuelQuantity += litersToAdd;
        }
    }
}
