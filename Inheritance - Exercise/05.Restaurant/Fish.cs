﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Fish : MainDish
    {
        public const double grams = 22;

        public Fish(string name, decimal price) : base(name, price, grams)
        {
        }
    }
}
