using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BirthdayCelebrations
{
    public class Robot
    {
        public Robot(string model, string iD)
        {
            Model = model;
            ID = iD;
        }

        public string Model { get; set; }

        public string ID { get; set; }
    }
}
