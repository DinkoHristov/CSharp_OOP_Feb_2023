using _08.CollectionHierarchy.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy.Models
{
    public class AddCollection : IAddCollection
    {
        private readonly List<string> data;

        public AddCollection()
        {
            data = new List<string>();
        }

        public int Add(string item)
        {
            data.Add(item);

            return data.Count - 1;
        }
    }
}
