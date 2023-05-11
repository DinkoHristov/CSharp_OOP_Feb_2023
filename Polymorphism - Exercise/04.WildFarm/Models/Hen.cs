using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, int foodEaten, double wingSize) 
            : base(name, weight, foodEaten, wingSize)
        {

        }

        public override void Eat(double pieces)
        {
            this.Weight += pieces * 0.35;

            this.FoodEaten += (int)pieces;
        }

        public override string Feed(string food)
        {
            return ToString();
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Cluck");
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
