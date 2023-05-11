using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private int load;
        private readonly ICollection<Item> items;

        public Bag(int capacity)
        {
            Capacity = capacity;
            items = new List<Item>();
        }

        public int Capacity { get; set; } = 100;

        public int Load { 
            get
            {
                int sum = 0;

                foreach (Item item in items)
                {
                    sum += item.Weight;
                }

                load = sum;

                return load;
            }
        }

        public IReadOnlyCollection<Item> Items
            => items.ToList().AsReadOnly();

        public void AddItem(Item item)
        {
            int currentWeight = Load + item.Weight;

            if (currentWeight > Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            items.Add(item);
        }

        public Item GetItem(string name)
        {
            Item item = items.FirstOrDefault(i => i.GetType().Name == name);

            if (items.Count <= 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            if (item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            items.Remove(item);

            return item;
        }
    }
}
