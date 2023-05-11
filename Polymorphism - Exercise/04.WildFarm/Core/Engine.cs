using _04.WildFarm.Core.Interfaces;
using _04.WildFarm.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            List<Animal> animals = new List<Animal>();
            List<Food> foods = new List<Food>();

            int count = 0;

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string animalType = inputArgs[0];

                Animal animal = null;

                try
                {
                    if (count % 2 != 0)
                    {
                        Food food = null;

                        string foodType = inputArgs[0];

                        if (foodType == "Vegetable")
                        {
                            food = new Vegetable(int.Parse(inputArgs[1]));
                        }
                        else if (foodType == "Meat")
                        {
                            food = new Meat(int.Parse(inputArgs[1]));
                        }
                        else if (foodType == "Fruit")
                        {
                            food = new Fruit(int.Parse(inputArgs[1]));
                        }
                        else if (foodType == "Seeds")
                        {
                            food = new Seeds(int.Parse(inputArgs[1]));
                        }

                        foods.Add(food);
                    }
                    else
                    {
                        if (animalType == "Owl")
                        {
                            animal =
                                new Owl(
                                    inputArgs[1],
                                    double.Parse(inputArgs[2]),
                                    0,
                                    double.Parse(inputArgs[3]));
                        }
                        else if (animalType == "Hen")
                        {
                            animal =
                                new Hen(
                                    inputArgs[1],
                                    double.Parse(inputArgs[2]),
                                    0,
                                    double.Parse(inputArgs[3]));
                        }

                        else if (animalType == "Mouse")
                        {
                            animal =
                                new Mouse(
                                    inputArgs[1],
                                    double.Parse(inputArgs[2]),
                                    0,
                                    inputArgs[3]);
                        }
                        else if (animalType == "Dog")
                        {
                            animal =
                                new Dog(
                                    inputArgs[1],
                                    double.Parse(inputArgs[2]),
                                    0,
                                    inputArgs[3]);
                        }
                        else if (animalType == "Cat")
                        {
                            animal =
                                new Cat(
                                    inputArgs[1],
                                    double.Parse(inputArgs[2]),
                                    0,
                                    inputArgs[3],
                                    inputArgs[4]);
                        }
                        else if (animalType == "Tiger")
                        {
                            animal =
                               new Tiger(
                                   inputArgs[1],
                                   double.Parse(inputArgs[2]),
                                   0,
                                   inputArgs[3],
                                   inputArgs[4]);
                        }

                        animals.Add(animal);
                    }

                    count++;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            for (int i = 0; i < animals.Count; i++)
            {
                Animal currAnimal = animals[i];
                Food currFood = foods[i];

                try
                {
                    currAnimal.ProduceSound();
                    currAnimal.Feed(currFood.GetType().Name);
                    currAnimal.Eat(currFood.Quantity);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
