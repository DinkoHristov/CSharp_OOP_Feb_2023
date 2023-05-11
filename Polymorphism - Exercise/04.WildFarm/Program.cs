using _04.WildFarm.Core;
using _04.WildFarm.Core.Interfaces;
using _04.WildFarm.Models;
using System;
using System.Collections.Generic;

namespace _04.WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
