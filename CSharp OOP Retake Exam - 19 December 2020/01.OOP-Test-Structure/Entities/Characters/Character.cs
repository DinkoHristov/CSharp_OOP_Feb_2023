using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		private string name;
		private double health;
		private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            BaseHealth = health;
            BaseArmor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
			Health = BaseHealth;
			Armor = BaseArmor;
        }

        // TODO: Implement the rest of the class.

        public string Name {
			get
			{
				return name;
			}
			private set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Name cannot be null or whitespace!");
				}

				name = value;
			}
		}

        public double BaseHealth { get; private set; }

        public double Health {
			get
			{
				return health;
			}
			set
			{
				if (health > BaseHealth)
				{
					health = BaseHealth;
				}
				else if (health < 0)
				{
					health = 0;
				}
				else
				{
                    health = value;
                }
            }
		}

        public double BaseArmor { get; private set; }

        public double Armor { 
			get
			{
				return armor;
			}
			private set
			{
                if (armor > BaseArmor)
                {
                    armor = BaseArmor;
                }
                else if (armor < 0)
                {
                    armor = 0;
                }
                else
                {
                    armor = value;
                }
            }
		}

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; set; }

        public bool IsAlive { get; set; } = true;

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

		public void TakeDamage(double hitPoints)
		{
			if (IsAlive)
			{
				double hitLeft = 0;

				if (hitPoints > Armor)
				{
					hitLeft = hitPoints - Armor;
					Armor = 0;

					if (hitLeft > Health)
					{
						Health = 0;

						IsAlive = false;
					}
					else
					{
						Health -= hitLeft;
					}
				}
				else
				{
					Armor -= hitPoints;
				}
			}
		}

		public void UseItem(Item item)
		{
			if (IsAlive)
			{
                item.AffectCharacter(this);
            }
        }
	}
}