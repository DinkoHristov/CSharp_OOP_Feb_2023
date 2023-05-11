using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, int foodEaten, double wingSize) 
            : base(name, weight, foodEaten, wingSize)
        {

        }

        public override void Eat(double pieces)
        {
            this.Weight += pieces * 0.25;

            this.FoodEaten += (int)pieces;
        }

        public override string Feed(string food)
        {
            if (food != "Meat")
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food}!");
            }

            return ToString();
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Hoot Hoot");
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
