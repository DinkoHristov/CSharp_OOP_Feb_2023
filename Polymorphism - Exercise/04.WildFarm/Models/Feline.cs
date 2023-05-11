using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    public class Feline : Mammal
    {
        public Feline(string name, double weight, int foodEaten, string livingRegion, string breed) 
            : base(name, weight, foodEaten, livingRegion)
        {
            Breed = breed;
        }

        public string Breed { get; private set; }

        public override void Eat(double pieces)
        {

        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
