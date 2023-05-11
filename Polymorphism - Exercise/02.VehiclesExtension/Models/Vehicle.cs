using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension.Models
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double tankFuel;

        protected Vehicle(double fuelQuantity, double litersPerKm, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            LitersPerKm = litersPerKm;
        }

        public double FuelQuantity {
            get
            {
                return this.fuelQuantity;
            }
            set
            {
                if (value > this.tankFuel)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public double LitersPerKm { get; private set; }

        public double TankCapacity {
            get
            {
                return this.tankFuel;
            }
            private set
            {
                this.tankFuel = value;
            }
        }

        public abstract string Drive(double kilometers);

        public abstract void Refuel(double litersToAdd);
    }
}
