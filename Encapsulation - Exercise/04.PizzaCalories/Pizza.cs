using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
            toppings = new List<Topping>();
        }
        public string Name {
            get
            {
                return this.name;
            }
            private set
            { 
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough { get; set; }

        public IReadOnlyCollection<Topping> Toppings {
            get
            {
                return this.toppings.AsReadOnly();
            }
        }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count >= 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }

        public decimal TotalCalories()
        {
            decimal totalCalories = 0;

            foreach (var topping in this.toppings)
            {
                totalCalories += topping.CaloriesPerGram;
            }

            totalCalories += Dough.CaloriesPerGram;

            return totalCalories;
        }
    }
}
