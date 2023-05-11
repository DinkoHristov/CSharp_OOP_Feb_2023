using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, int foodEaten, string livingRegion, string breed)
            : base(name, weight, foodEaten, livingRegion, breed)
        {

        }

        public override void Eat(double pieces)
        {
            this.Weight += pieces * 1.00;

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
            Console.WriteLine("ROAR!!!");
        }


        public override string ToString()
        {
            return base.ToString();
        }
    }
}
