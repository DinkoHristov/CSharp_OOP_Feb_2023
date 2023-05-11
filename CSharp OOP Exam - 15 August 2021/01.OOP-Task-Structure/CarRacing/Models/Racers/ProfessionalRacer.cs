using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const int initialExperience = 30;
        private const string initialBehavior = "strict";

        public ProfessionalRacer(string username, ICar car) 
            : base(username, initialBehavior, initialExperience, car)
        {

        }

        public override void Race()
        {
            Car.Drive();

            DrivingExperience += 10;
        }
    }
}
