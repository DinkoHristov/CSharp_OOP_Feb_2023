using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, int foodEaten, string livingRegion) 
            : base(name, weight, foodEaten, livingRegion)
        {

        }

        public override void Eat(double pieces)
        {
            this.Weight += pieces * 0.10;

            this.FoodEaten += (int)pieces;
        }

        public override string Feed(string food)
        {
            if (food != "Vegetable" && food != "Fruit")
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food}!");
            }

            return ToString();
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Squeak");
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
