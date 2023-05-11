using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Beast!")
            {
                string animalType = command;
                string[] animalArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = animalArgs[0];
                int age = int.Parse(animalArgs[1]);
                string gender = animalArgs[2];

                if (animalType == "Cat")
                {
                    try
                    {
                        Cat cat = new Cat(name, age, gender);
                        Console.WriteLine(animalType);
                        Console.WriteLine(cat.ToString());
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                else if (animalType == "Dog")
                {
                    try
                    {
                        Dog dog = new Dog(name, age, gender);
                        Console.WriteLine(animalType);
                        Console.WriteLine(dog.ToString());
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                else if (animalType == "Frog")
                {
                    try
                    {
                        Frog frog = new Frog(name, age, gender);
                        Console.WriteLine(animalType);
                        Console.WriteLine(frog.ToString());
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                else if (animalType == "Kitten")
                {
                    try
                    {
                        Kitten kitten = new Kitten(name, age);
                        Console.WriteLine(animalType);
                        Console.WriteLine(kitten.ToString());
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                else if (animalType == "Tomcat")
                {
                    try
                    {
                        Tomcat tomcat = new Tomcat(name, age);
                        Console.WriteLine(animalType);
                        Console.WriteLine(tomcat.ToString());
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            }
        }
    }
}
