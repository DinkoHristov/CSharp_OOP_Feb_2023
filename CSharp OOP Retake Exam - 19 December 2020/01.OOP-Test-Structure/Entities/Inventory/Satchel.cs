using System;
using System.Collections.Generic;
using System.Text;

namespace WarCroft.Entities.Inventory
{
    public class Satchel : Bag
    {
        private const int initialCapacity = 20;

        public Satchel() 
            : base(initialCapacity)
        {
        }
    }
}
