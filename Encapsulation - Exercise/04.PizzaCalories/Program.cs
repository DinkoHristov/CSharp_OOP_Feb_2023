using System;

namespace _04.PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] pizzaInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = string.Empty;

            if (pizzaInfo.Length > 1)
            {
                name = pizzaInfo[1];
            }

            string[] doughInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string flour = doughInfo[1];
            string bakingType = doughInfo[2];
            decimal calories = decimal.Parse(doughInfo[3]);

            try
            {
                Dough dough = new Dough(flour, bakingType, calories);
                Pizza currPizza = new Pizza(name, dough);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);

                return;
            }

            Pizza pizza = new Pizza(name, new Dough(flour, bakingType, calories));

            string toppingg = string.Empty;
            while ((toppingg = Console.ReadLine()).ToLower() != "end")
            {
                string[] toppingInfo = toppingg.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string toppingType = toppingInfo[1];
                decimal toppingCalories = decimal.Parse(toppingInfo[2]);

                try
                {
                    Topping topping = new Topping(toppingType, toppingCalories);

                    pizza.AddTopping(topping);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);

                    return;
                }
            }

            Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories()} Calories.");
        }
    }
}
