using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    public class Mammal : Animal
    {
        public Mammal(string name, double weight, int foodEaten, string livingRegion) 
            : base(name, weight, foodEaten)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }

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
            return $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";

        }
    }
}
