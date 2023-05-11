using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public int HorsePower { get; set; }

        public double Fuel { get; set; }

        public double DefaultFuelConsumption { get; set; } = 1.25;

        public virtual double FuelConsumption  { get { return DefaultFuelConsumption;} }

        public virtual void Drive(double kilometers)
        {
            //Reduce the Fuel based on the kilometers.
            Fuel -= FuelConsumption * kilometers;
        }
    }
}
