using System;

namespace _09.ExplicitInterfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = inputArgs[0];
                string country = inputArgs[1];
                int age = int.Parse(inputArgs[2]);

                Citizen citizen = new Citizen(name, country, age);

                IPerson person = citizen;
                Console.WriteLine(person.GetName());

                IResident resident = citizen;
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
