using _02.VehiclesExtension.Core.Interfaces;
using _02.VehiclesExtension.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            string[] carInfo = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Vehicle car =
                new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));

            string[] truckInfo = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Vehicle truck =
                new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));

            string[] busInfo = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Vehicle bus =
                new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string commandType = input[0];

                try
                {
                    if (commandType == "Drive")
                    {
                        string vehicleType = input[1];
                        double kilometers = double.Parse(input[2]);

                        if (vehicleType == "Car")
                        {
                            Console.WriteLine(car.Drive(kilometers));
                        }
                        else if (vehicleType == "Truck")
                        {
                            Console.WriteLine(truck.Drive(kilometers));
                        }
                        else if (vehicleType == "Bus")
                        {
                            Console.WriteLine(bus.Drive(kilometers));
                        }
                    }
                    else if (commandType == "Refuel")
                    {
                        string vehicleType = input[1];
                        double litersToRefuel = double.Parse(input[2]);

                        if (vehicleType == "Car")
                        {
                            car.Refuel(litersToRefuel);
                        }
                        else if (vehicleType == "Truck")
                        {
                            truck.Refuel(litersToRefuel);
                        }
                        else if (vehicleType == "Bus")
                        {
                            bus.Refuel(litersToRefuel);
                        }
                    }
                    else if (commandType == "DriveEmpty")
                    {
                        double kilometers = double.Parse(input[2]);

                        if (input[1] == "Bus")
                        {
                            Console.WriteLine(((Bus)bus).DriveWithoutPeople(kilometers));
                        }
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
    }
}
