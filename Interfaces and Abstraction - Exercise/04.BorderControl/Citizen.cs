using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public class Citizen : IId
    {
        public Citizen(string name, int age, string iD)
        {
            Name = name;
            Age = age;
            ID = iD;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string ID { get; set; }
    }
}
