using Heroes.Models;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Heroes.Core.Contracts
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;

        public Controller()
        {
           this.heroes = new HeroRepository();
           this.weapons = new WeaponRepository();
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            if (!this.heroes.Models.Any(h => h.Name == heroName))
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }

            if (!this.weapons.Models.Any(w => w.Name == weaponName))
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }

            IHero hero = this.heroes.Models.FirstOrDefault(h => h.Name == heroName);
            IWeapon weapon = this.weapons.Models.FirstOrDefault(w => w.Name == weaponName);

            if (hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }

            hero.AddWeapon(weapon);

            return $"Hero {heroName} can participate in battle using a {(hero.Weapon.GetType().Name).ToLower()}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (this.heroes.Models.Any(h => h.Name == name))
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }

            if (type != "Knight" && type != "Barbarian")
            {
                throw new InvalidOperationException("Invalid hero type.");
            }

            IHero hero = null;

            if (type == "Knight")
            {
                hero = new Knight(name, health, armour);

                this.heroes.Add(hero);

                return $"Successfully added Sir {name} to the collection.";
            }
            else if (type == "Barbarian")
            {
                hero = new Barbarian(name, health, armour);

                this.heroes.Add(hero);

                return $"Successfully added Barbarian {name} to the collection.";
            }

            return null;
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (this.weapons.Models.Any(h => h.Name == name))
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }

            if (type != "Mace" && type != "Claymore")
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }

            IWeapon weapon = null;

            if (type == "Mace")
            {
                weapon = new Mace(name, durability);
            }
            else if (type == "Claymore")
            {
                weapon = new Claymore(name, durability);
            }

            this.weapons.Add(weapon);

            return $"A {type.ToLower()} {name} is added to the collection.";
        }

        public string HeroReport()
        {
            StringBuilder result = new StringBuilder();

            foreach (var hero in this.heroes.Models
                .OrderBy(type => type.GetType().Name)
                .ThenByDescending(health => health.Health)
                .ThenBy(name => name.Name))
            {
                result.AppendLine(hero.ToString());
            }

            return result.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            IMap map = new Map();
            List<IHero> allHeroes = this.heroes.Models
                .Where(h => h.IsAlive == true && h.Weapon != null).ToList();

            string result = map.Fight(allHeroes);

            return result;
        }
    }
}
