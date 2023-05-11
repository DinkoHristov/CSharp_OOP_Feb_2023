using System;
using System.Collections.Generic;

namespace _05.BirthdayCelebrations
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IBirthDate> birthDates = new List<IBirthDate>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string classType = inputArgs[0];

                if (classType == "Citizen")
                {
                    string name = inputArgs[1];
                    int age = int.Parse(inputArgs[2]);
                    string id = inputArgs[3];
                    string birthDate = inputArgs[4];

                    Citizen citizen = new Citizen(name, age, id, birthDate);

                    birthDates.Add(citizen);
                }
                else if (classType == "Pet")
                {
                    string name = inputArgs[1];
                    string birthDate = inputArgs[2];

                    Pet pet = new Pet(name, birthDate);

                    birthDates.Add(pet);
                }
            }

            string birthToSearch = Console.ReadLine();

            foreach (var birthDate in birthDates)
            {
                string birthYear = birthDate.BirthDate[6..birthDate.BirthDate.Length];

                if (birthYear == birthToSearch)
                {
                    Console.WriteLine(birthDate.BirthDate);
                }
            }
        }
    }
}
