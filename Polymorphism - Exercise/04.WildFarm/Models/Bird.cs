using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    public class Bird : Animal
    {
        public Bird(string name, double weight, int foodEaten, double wingSize) 
            : base(name, weight, foodEaten)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; private set; }

        public override void Eat(double pieces)
        {

        }

        public override string Feed(string food)
        {
            return null;
        }

        public override void ProduceSound()
        {

        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
