using _08.CollectionHierarchy.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy.Models
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private const int AddIndex = 0;

        private readonly List<string> data;

        public AddRemoveCollection()
        {
            data = new List<string>();
        }

        public int Add(string item)
        {
            data.Insert(AddIndex, item);

            return AddIndex;
        }

        public string Remove()
        {
            string item = null;

            if (data.Count > 0)
            {
                item = data[data.Count - 1];

                data.RemoveAt(data.Count - 1);
            }

            return item;
        }
    }
}
