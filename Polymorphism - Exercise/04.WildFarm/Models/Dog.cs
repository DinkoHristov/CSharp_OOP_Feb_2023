using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, int foodEaten, string livingRegion) 
            : base(name, weight, foodEaten, livingRegion)
        {

        }

        public override void Eat(double pieces)
        {
            this.Weight += pieces * 0.40;

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
            Console.WriteLine("Woof!");
        }


        public override string ToString()
        {
            return base.ToString();
        }
    }
}
