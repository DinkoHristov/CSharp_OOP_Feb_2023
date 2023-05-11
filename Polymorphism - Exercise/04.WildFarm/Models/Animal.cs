using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    public abstract class Animal
    {
        protected Animal(string name, double weight, int foodEaten)
        {
            Name = name;
            Weight = weight;
            FoodEaten = foodEaten;
        }

        public string Name { get; private set; }

        public double Weight { get; set; }

        public int FoodEaten { get; set; }

        public abstract void ProduceSound();

        public abstract void Eat(double pieces);

        public abstract string Feed(string food);
    }
}
