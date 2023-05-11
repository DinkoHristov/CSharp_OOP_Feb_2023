using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public class Aquarium : IAquarium
    {
        private string name;
        private readonly ICollection<IDecoration> decorations;
        private readonly ICollection<IFish> fish;
        private int comfort;

        public Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            decorations = new List<IDecoration>();
            fish = new List<IFish>();
        }

        public string Name {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }

                name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort { 
            get
            {
                int decorationSum = 0;

                foreach (IDecoration decoration in decorations)
                {
                    decorationSum += decoration.Comfort;
                }

                comfort = decorationSum;

                return comfort;
            }
        }

        public ICollection<IDecoration> Decorations
            => decorations.ToList().AsReadOnly();

        public ICollection<IFish> Fish
            => fish.ToList().AsReadOnly();

        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.fish.Count >= Capacity)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }

            this.fish.Add(fish);
        }

        public void Feed()
        {
            foreach (IFish fish in this.fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{Name} ({this.GetType().Name}):");

            if (fish.Count > 0)
            {
                List<string> fishNames = new List<string>();

                foreach (IFish fish in this.fish)
                {
                    fishNames.Add(fish.Name);
                }

                result.AppendLine($"Fish: {string.Join(", ", fishNames)}");
            }
            else
            {
                result.AppendLine($"Fish: none");
            }

            result.AppendLine($"Decorations: {decorations.Count}");
            result.AppendLine($"Comfort: {Comfort}");

            return result.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            if (this.fish.Any(f => f == fish))
            {
                this.fish.Remove(fish);

                return true;
            }

            return false;
        }
    }
}
