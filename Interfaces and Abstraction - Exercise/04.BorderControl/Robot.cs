using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public class Robot : IId
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
