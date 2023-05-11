using _08.CollectionHierarchy.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy.Models
{
    public class MyList : IMyList
    {
        private const int AddIndex = 0;
        private const int RemoveIndex = 0;

        private readonly List<string> data;

        public MyList()
        {
            data = new List<string>();
        }

        public int Used => data.Count;

        public int Add(string item)
        {
            data.Insert(AddIndex, item);

            return AddIndex;
        }

        public string Remove()
        {
            string item = data[RemoveIndex];

            data.RemoveAt(RemoveIndex);

            return item;
        }
    }
}
