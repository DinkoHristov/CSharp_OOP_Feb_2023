using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage
{
    public class Rebel : IBuyer
    {
        private int food;

        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Group { get; set; }

        public int Food {
            get
            {
                return this.food;
            }
            private set
            {
                this.food = 0;
            }
        }

        public void BuyFood()
        {
            this.food += 5;
        }
    }
}
