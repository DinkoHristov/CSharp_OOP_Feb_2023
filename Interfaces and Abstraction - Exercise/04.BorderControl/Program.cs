using System;
using System.Collections.Generic;

namespace _04.BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IId> ids = new List<IId>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (inputArgs.Length == 2)
                {
                    // It's a robot
                    string model = inputArgs[0];
                    string id = inputArgs[1];

                    Robot robot = new Robot(model, id);

                    ids.Add(robot);
                }
                else
                {
                    // It's a citizen
                    string name = inputArgs[0];
                    int age = int.Parse(inputArgs[1]);
                    string id = inputArgs[2];

                    Citizen citizen = new Citizen(name, age, id);

                    ids.Add(citizen);
                }
            }

            string idToSearch = Console.ReadLine();
            int idLength = idToSearch.Length;

            foreach (var id in ids)
            {
                int currIdLength = id.ID.Length;

                string currId = id.ID[(currIdLength - idLength)..currIdLength];

                if (currId == idToSearch)
                {
                    Console.WriteLine(id.ID);
                }
            }
        }
    }
}
