using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private string toppingType;
        private decimal caloriesPerGram;

        public Topping(string toppingType, decimal calories)
        {
            ToppingType = toppingType;
            CaloriesPerGram = calories;
        }

        private string ToppingType {
            get
            {
                return this.toppingType;
            }
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" &&
                    value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.toppingType = value;
            }
        }

        public decimal CaloriesPerGram {
            get
            { 
                return this.caloriesPerGram;
            }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.toppingType} weight should be in the range [1..50].");
                }

                decimal totalCalories = 0;

                if (this.toppingType.ToLower() == "meat")
                {
                    // 1.2
                    totalCalories = value * 1.2m * 2;
                }
                else if (this.toppingType.ToLower() == "veggies")
                {
                    // 0.8
                    totalCalories = value * 0.8m * 2;
                }
                else if (this.toppingType.ToLower() == "cheese")
                {
                    // 1.1
                    totalCalories = value * 1.1m * 2;
                }
                else if (this.toppingType.ToLower() == "sauce")
                {
                    // 0.9
                    totalCalories = value * 0.9m * 2;
                }

                this.caloriesPerGram = totalCalories;
            }
        }
    }
}
