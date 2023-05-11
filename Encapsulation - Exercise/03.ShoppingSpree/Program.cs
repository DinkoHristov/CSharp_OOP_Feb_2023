using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> allPersons = new List<Person>();

            string[] persons = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0 ;i < persons.Length; i++)
            {
                string[] currPerson = persons[i].Split("=", StringSplitOptions.RemoveEmptyEntries);

                string name = currPerson[0];
                decimal money = decimal.Parse(currPerson[1]);

                try
                {
                    Person person = new Person(name, money);
                    allPersons.Add(person);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    return;
                }
            }

            List<Product> allProducts = new List<Product>();

            string[] products = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < products.Length; i++)
            {
                string[] productInfo = products[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                string name = productInfo[0];
                decimal cost = decimal.Parse(productInfo[1]);

                try
                {
                    Product product = new Product(name, cost);
                    allProducts.Add(product);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    return;
                }
            }

            Dictionary<string, List<string>> boughtProducts = new Dictionary<string, List<string>>();
            foreach (var person in allPersons)
            {
                boughtProducts.Add(person.Name, new List<string>());
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string personName = commandArgs[0];
                string productName = commandArgs[1];

                foreach (var person in allPersons
                    .Where(p => p.Name == personName))
                {
                    if (allProducts.Any(p => p.Name == productName))
                    {
                        Product product = allProducts.FirstOrDefault(p => p.Name == productName);

                        if (person.Money < product.Cost)
                        {
                            Console.WriteLine($"{personName} can't afford {productName}");
                            continue;
                        }

                        boughtProducts[person.Name].Add(productName);
                        person.Money -= product.Cost;

                        Console.WriteLine($"{personName} bought {productName}");
                    }
                }
            }

            foreach (var person in boughtProducts)
            {
                if (person.Value.Count > 0)
                {
                    Console.WriteLine($"{person.Key} - {string.Join(", ", person.Value)}");
                }
                else
                {
                    Console.WriteLine($"{person.Key} - Nothing bought");
                }
            }
        }
    }
}
