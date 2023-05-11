using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, int foodEaten, string livingRegion, string breed) 
            : base(name, weight, foodEaten, livingRegion, breed)
        {

        }

        public override void Eat(double pieces)
        {
            this.Weight += pieces * 0.30;

            this.FoodEaten += (int)pieces;
        }

        public override string Feed(string food)
        {
            if (food != "Vegetable" && food != "Meat")
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food}!");
            }

            return ToString();
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }


        public override string ToString()
        {
            return base.ToString();
        }
    }
}
