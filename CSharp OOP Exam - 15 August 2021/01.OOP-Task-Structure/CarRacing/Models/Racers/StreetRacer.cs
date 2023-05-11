using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const int initialExperience = 10;
        private const string initialBehavior = "aggressive";

        public StreetRacer(string username, ICar car) 
            : base(username, initialBehavior, initialExperience, car)
        {

        }

        public override void Race()
        {
            Car.Drive();

            DrivingExperience += 5;
        }
    }
}
