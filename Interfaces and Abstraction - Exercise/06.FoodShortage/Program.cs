using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.FoodShortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IBuyer> people = new List<IBuyer>();

            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                string[] inputArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (inputArgs.Length == 3)
                {
                    // It's a rebel
                    string name = inputArgs[0];
                    int age = int.Parse(inputArgs[1]);
                    string group = inputArgs[2];

                    Rebel rebel = new Rebel(name, age, group);

                    people.Add(rebel);
                }
                else
                {
                    // It's a citizen
                    string name = inputArgs[0];
                    int age = int.Parse(inputArgs[1]);
                    string iD = inputArgs[2];
                    string birthDate = inputArgs[3];

                    Citizen citizen = new Citizen(name, age, iD, birthDate);

                    people.Add(citizen);
                }
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                if (people.Any(p => p.Name == input))
                {
                    IBuyer product = people.FirstOrDefault(p => p.Name == input);
                    product.BuyFood();
                }
            }

            int boughtFood = 0;
            foreach (var man in people)
            {
                boughtFood += man.Food;
            }

            Console.WriteLine(boughtFood);
        }
    }
}
