using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return "Race cannot be completed because both racers are not available!";
            }

            if (!racerOne.IsAvailable())
            {
                racerTwo.Race();

                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }

            if (!racerTwo.IsAvailable())
            {
                racerOne.Race();

                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }

            double racerOneMultiplier = 1;

            if (racerOne.RacingBehavior == "strict")
            {
                racerOneMultiplier = 1.2;
            }
            else if (racerOne.RacingBehavior == "aggressive")
            {
                racerOneMultiplier = 1.1;
            }

            double racerOneChanceOfWinning = racerOne.Car.HorsePower * racerOne.DrivingExperience * racerOneMultiplier;

            double racerTwoMultiplier = 1;

            if (racerTwo.RacingBehavior == "strict")
            {
                racerTwoMultiplier = 1.2;
            }
            else if (racerTwo.RacingBehavior == "aggressive")
            {
                racerTwoMultiplier = 1.1;
            }

            double racerTwoChanceOfWinning = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racerTwoMultiplier;

            racerOne.Race();
            racerTwo.Race();

            if (racerOneChanceOfWinning > racerTwoChanceOfWinning)
            {
                return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerOne.Username} is the winner!";
            }
            else
            {
                return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerTwo.Username} is the winner!";
            }
        }
    }
}
