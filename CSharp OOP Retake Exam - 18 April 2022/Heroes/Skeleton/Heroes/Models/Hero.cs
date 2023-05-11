using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models
{
    public class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private bool isAlive;
        private IWeapon weapon;

        public Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
            this.IsAlive = isAlive;
        }

        public string Name {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int Health {
            get
            {
                return this.health;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }

                this.health = value;
            }
        }

        public int Armour {
            get
            {
                return this.armour;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }

                this.armour = value;
            }
        }

        public IWeapon Weapon {
            get
            {
                return this.weapon;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }

                this.weapon = value;
            }
        }

        public bool IsAlive {
            get
            {
                return this.isAlive;
            }
            set
            { 
                if (this.Health > 0)
                {
                    this.isAlive = true;
                }
                else
                {
                    this.isAlive = false;
                }
            }
        }

        public void AddWeapon(IWeapon weapon)
        {
            if (this.weapon == null)
            {
                this.weapon = weapon;
            }
        }

        public void TakeDamage(int points)
        {
            int currentPoints = points;

            if (this.armour - currentPoints >= 0)
            {
                this.armour -= currentPoints;
            }
            else if (this.armour - currentPoints < 0)
            {
                currentPoints = currentPoints - this.armour;
                this.armour = 0;
                this.health -= currentPoints;
            }

            if (this.health <= 0)
            {
                this.health = 0;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{GetType().Name}: {Name}");
            result.AppendLine($"--Health: {Health}");
            result.AppendLine($"--Armour: {Armour}");

            if (Weapon == null)
            {
                result.AppendLine("--Weapon: Unarmed");
            }
            else
            {
                result.AppendLine($"--Weapon: {Weapon.Name}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
