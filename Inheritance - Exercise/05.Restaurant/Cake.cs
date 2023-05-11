﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        public const decimal price = 5m;
        public const double grams = 250;
        public const double calories = 1000;

        public Cake(string name) :
            base(name, price, grams, calories)
        {
           
        }
    }
}
