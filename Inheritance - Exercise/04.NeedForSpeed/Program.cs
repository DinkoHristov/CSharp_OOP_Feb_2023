using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SportCar sportCar = new SportCar(300, 30);

            FamilyCar familyCar = new FamilyCar(120, 50);

            RaceMotorcycle raceMotor = new RaceMotorcycle(500, 80);

            CrossMotorcycle crossMotor = new CrossMotorcycle(326, 45);

            sportCar.Drive(89.65);
        }
    }
}
