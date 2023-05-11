using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.name = value;
            }
        }

        public int Age {
            get
            {
                return this.age;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.age = value;
            }
        }

        public string Gender {
            get
            {
                return this.gender;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.gender = value;
            }
        }

        public abstract string ProduceSound();

        public override string ToString() => $"{Name} {Age} {Gender}{Environment.NewLine}{ProduceSound()}";
    }
}
