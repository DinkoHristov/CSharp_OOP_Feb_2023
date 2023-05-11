using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage
{
    public class Citizen : IBuyer
    {
        private int food;

        public Citizen(string name, int age, string iD, string birthDate)
        {
            Name = name;
            Age = age;
            ID = iD;
            BirthDate = birthDate;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string ID { get; set; }

        public string BirthDate { get; set; }

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
            this.food += 10;
        }
    }
}
