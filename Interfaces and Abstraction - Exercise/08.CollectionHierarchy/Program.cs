using _08.CollectionHierarchy.Core;
using _08.CollectionHierarchy.Core.Interfaces;
using System;

namespace _08.CollectionHierarchy
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
