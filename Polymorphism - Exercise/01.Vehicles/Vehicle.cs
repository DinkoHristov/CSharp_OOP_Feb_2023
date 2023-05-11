using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double litersPerKm)
        {
            FuelQuantity = fuelQuantity;
            LitersPerKm = litersPerKm;
        }

        public double FuelQuantity { get; set; }

        public double LitersPerKm { get; set; }

        public abstract string Drive(double kilometers);

        public abstract void Refuel(double litersToAdd);
    }
}
